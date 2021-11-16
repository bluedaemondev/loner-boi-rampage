using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public enum Language
{
    eng,
    spa
}

public class LangManager : MonoBehaviour
{
    public static LangManager Instance
    {
        get
        {
            return _instance;
        }
    }

    static LangManager _instance;

    //Enum para saber en que idioma se va a ejecutar en un principio
    public Language? selectedLanguage;
    public Language defaultLanguage = Language.eng;

    //Diccionario de lenguaje, que va a contener otro diccionario que va a tomar de
    //key un ID y como Value el Texto correspondiente
    public Dictionary<Language, Dictionary<string, string>> languageManager;

    //URL para saber de donde descargar nuestro documento
    public string externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQnrW6J4o5eliDhS3AZds4bV-5vk1PD68qrjucb4njUAAYkIdXIZPgwgavQSjDqzdq4a88tATvXyuqI/pub?gid=0&single=true&output=csv";

    //Un evento para actualizar cuando se tiene que cambiar el idioma
    public event Action onUpdate = delegate { };

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }

        _instance = this;

        StartCoroutine(DownloadCSV(externalURL)); //Bajamos el archivo de inet
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (selectedLanguage == Language.eng)
                selectedLanguage = Language.spa;
            else
                selectedLanguage = Language.eng;

            onUpdate();
        }
    }

    public string GetTranslate(string id)
    {
        if (selectedLanguage != null && !languageManager[selectedLanguage ?? defaultLanguage].ContainsKey(id))
            return "Error 404: Not Found";
        else
            return languageManager[selectedLanguage ?? defaultLanguage][id];
    }

    /// <summary>
    /// Bajamos el documento desde la pag. indicada por parametro y lo cortamos con la funcion dentro de LanguageU
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        languageManager = LanguageU.LoadCodexFromString("www", www.downloadHandler.text);

        onUpdate();
    }
}
