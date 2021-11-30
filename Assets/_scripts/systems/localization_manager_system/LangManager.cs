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

    private static LangManager _instance;

    //Enum para saber en que idioma se va a ejecutar en un principio
    public Language? selectedLanguage;
    public Language defaultLanguage;

    public Dictionary<Language, Dictionary<string, string>> languageManager;

    public string externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQnrW6J4o5eliDhS3AZds4bV-5vk1PD68qrjucb4njUAAYkIdXIZPgwgavQSjDqzdq4a88tATvXyuqI/pub?gid=0&single=true&output=csv";

    public event Action onUpdate = delegate { };

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        StartCoroutine(DownloadCSV(externalURL)); //Bajamos el archivo de inet
    }
    private void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_LOAD_PREFS, LoadPreexistingData);
    }

    private void LoadPreexistingData(params object[] data)
    {

        defaultLanguage = ((Prefs)data[0]).language;
        selectedLanguage = ((Prefs)data[0]).language;

        Debug.Log(selectedLanguage.ToString());
        //TranslateUpdate();
    }

    /// <summary>
    /// Editor method - change language
    /// </summary>
    public void TranslateUpdate()
    {
        if (selectedLanguage == Language.eng)
            selectedLanguage = Language.spa;
        else
            selectedLanguage = Language.eng;

        onUpdate();
        PlayerPrefsManager.Instance.prefUser.language = selectedLanguage.Value;
        //Debug.Log("Update " + PlayerPrefsManager.Instance.prefUser.language);


    }
    public string GetTranslate(string id)
    {
        if (languageManager != null && !languageManager[selectedLanguage ?? defaultLanguage].ContainsKey(id))
            return "Error 404: Not Found";
        else if (languageManager != null)
            return languageManager[selectedLanguage ?? defaultLanguage][id];
        else
            return string.Empty;
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

        //if (selectedLanguage != PlayerPrefsManager.Instance.prefUser.language)
            onUpdate();
    }
}
