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
    public static PlayerPrefsManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private static PlayerPrefsManager _instance;
    public Prefs prefUser;

    public string folderPath = "";
    public string filename = ".data.s";

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


        prefUser = new Prefs();

        StartCoroutine(GetFileLoad());
    }
    //private IEnumerator OnLevelWasLoaded(int level)
    //{
        
    //}

    private IEnumerator GetFileLoad()
    {
        yield return StartCoroutine(LoadPrefsFile<Prefs>());

        EventManager.ExecuteEvent(Constants.ON_LOAD_PREFS, prefUser);
    }

    public string GetFileName()
    {
        return Path.Combine(GetFileDirectory(), filename);
    }
    public string GetFileDirectory()
    {
        return Path.Combine(Application.persistentDataPath, folderPath);
    }

    IEnumerator LoadPrefsFile<T>()
    {
        if (!File.Exists(GetFileName()))
        {
            this.prefUser = new Prefs();

            this.prefUser.levelData = new List<LevelPrefs>();
            // this.prefUser.configs
            prefUser.levelData.Add(
                new LevelPrefs
                {
                    level = 0,
                    bestTime = float.MaxValue,
                    maxAccuracy = 0,
                    maxPoints = 0
                });

            //yield return SavePrefs<Prefs>();

            yield break;
        }

        try
        {
            StreamReader _sReader = new StreamReader(GetFileName());

            string fileEnum = _sReader.ReadToEnd();

            _sReader.Dispose();

            //Debug.Log(fileEnum);

            this.prefUser = JsonUtility.FromJson<Prefs>(fileEnum);
            
        }
        catch (System.Exception exe)
        {
            Debug.LogError(exe.Data);
        }

        yield return null;


    }

    public IEnumerator SavePrefs<T>()
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo(GetFileDirectory());
            if (!dir.Exists)
                dir.Create();

            if (dir.Attributes.HasFlag(FileAttributes.ReadOnly))
            {
                dir.Attributes ^= FileAttributes.ReadOnly;
            }
            //if (File.Exists(GetFileName()))
            //{
            //    File.Delete(GetFileName());

            //}

            StreamWriter _sWriter = new StreamWriter(GetFileName());

            Debug.Log(JsonUtility.ToJson(this.prefUser, true));

            _sWriter.Write(JsonUtility.ToJson(this.prefUser, true));
            _sWriter.Dispose();
        }
        catch (System.Exception exe)
        {
            Debug.LogError(exe.Message);
        }

        yield return null;
    }

}

[System.Serializable]
public class Prefs
{
    public List<LevelPrefs> levelData;
    public ConfigPrefs configs;
    public Language language;

    public Prefs()
    {
        this.levelData = new List<LevelPrefs>();
        this.configs = new ConfigPrefs
        {
            sfxLevel = 100,
            isImplemented = false
        };
    }
}

[System.Serializable]
public class LevelPrefs
{
    public int level;
    public int maxPoints;
    public float bestTime;
    public float maxAccuracy;

}

[System.Serializable]
public class ConfigPrefs
{
    public float sfxLevel = 100;
    public bool isImplemented = false;
}
