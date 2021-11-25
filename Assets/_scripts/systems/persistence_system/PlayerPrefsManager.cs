using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Contiene las preferencias actuales/datos del nivel
/// 
/// </summary>
public class PlayerPrefsManager : MonoBehaviour
{
    public Prefs prefUser;

    public string literalPath = "";
    public string filename = ".data.s";

    private IEnumerator OnLevelWasLoaded(int level)
    {
        yield return StartCoroutine(LoadPrefsFile<Prefs>());
        EventManager.ExecuteEvent(Constants.ON_LOAD_PREFS, prefUser);
    }
    private void Awake()
    {
        
    }

    public string GetFileName()
    {
        return string.Format(Application.persistentDataPath, "\\", literalPath, "\\", filename);
    }
    
    
    IEnumerator LoadPrefsFile<T>() 
    {
        if (!File.Exists(GetFileName()))
        {
            this.prefUser = new Prefs();

            yield return SavePrefs(prefUser);

            yield break;
        }

        try 
        {
            StreamReader _sReader = new StreamReader(GetFileName());

            string fileEnum = _sReader.ReadToEnd();

            _sReader.Dispose();
            
            this.prefUser = JsonUtility.FromJson<Prefs>(fileEnum); 
            // hecho con alambre hasta que agregue las config

        } 
        catch(System.Exception exe)
        {
            Debug.LogError(exe.Data);
        }

        yield return null;

        
    }

    public IEnumerator SavePrefs<T>(T newPrefs)
    {
        try
        {
            StreamWriter _sWriter = new StreamWriter(GetFileName());
            _sWriter.Write(JsonUtility.ToJson(newPrefs, true));
            _sWriter.Dispose();
        }
        catch (System.Exception exe)
        {
            Debug.LogError(exe.Data);
        }

        yield return null;
    }

}
public class Prefs 
{
    public List<LevelPrefs> levelData;
    public ConfigPrefs configs;
}

public class LevelPrefs
{
    public int level;
    public int maxPoints;
    public float bestTime;
    public float maxAccuracy;

}
public class ConfigPrefs
{
    public float sfxLevel = 100;
    public bool isImplemented = false;
}
