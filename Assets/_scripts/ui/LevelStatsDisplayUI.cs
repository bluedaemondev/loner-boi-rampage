using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStatsDisplayUI : MonoBehaviour
{
    public static LevelStatsDisplayUI Instance
    {
        get
        {
            return _instance;
        }
    }

    private static LevelStatsDisplayUI _instance;

    [SerializeField] Text _selectedLevelContainer;
    [SerializeField] Text _selectedLevelDescription;
    [SerializeField] Text _selectedLevelMaxCash;
    [SerializeField] Text _selectedLevelBestTime;
    [SerializeField] Text _selectedLevelBestAccuracy;

    [SerializeField] Button _playLevelButton;

    string _selectedLevelContainerFormat;
    string _selectedLevelDescriptionFormat;
    string _selectedLevelMaxCashFormat;
    string _selectedLevelBestTimeFormat;
    string _selectedLevelBestAccuracyFormat;

    int levelToLoad;


    // Start is called before the first frame update
    void Awake()
    {
        if (!_instance)
            _instance = this;

        _selectedLevelContainerFormat = _selectedLevelContainer.text;
        _selectedLevelDescriptionFormat = _selectedLevelDescription.text;
        _selectedLevelMaxCashFormat = _selectedLevelMaxCash.text;
        _selectedLevelBestTimeFormat = _selectedLevelBestTime.text;
        _selectedLevelBestAccuracyFormat = _selectedLevelBestAccuracy.text;

        _selectedLevelContainer.text = "???";
        _selectedLevelDescription.text = string.Empty;
        _selectedLevelMaxCash.text = string.Empty;
        _selectedLevelBestTime.text = string.Empty;
        _selectedLevelBestAccuracy.text = string.Empty;

    }

    public void UpdateLevelStats(int levelId, string descript = "KILL KILL KILL"/*, int maxCash, float bestTime, float bestAcc*/)
    {
        levelToLoad = levelId;

        if (PlayerPrefsManager.Instance.prefUser.levelData.Count <= levelId)
        {
            _selectedLevelContainer.text = "(. _ .)";
            _selectedLevelDescription.text = string.Empty;
            _selectedLevelMaxCash.text = string.Empty;
            _selectedLevelBestTime.text = string.Empty;
            _selectedLevelBestAccuracy.text = string.Empty;

            _playLevelButton.interactable = true;

            return;
        }

        _playLevelButton.interactable = true;

        _selectedLevelContainer.text = string.Format(_selectedLevelContainerFormat, levelId);
        _selectedLevelDescription.text = descript;
        _selectedLevelMaxCash.text = string.Format(_selectedLevelMaxCashFormat, PlayerPrefsManager.Instance.prefUser.levelData[levelId].maxPoints);
        _selectedLevelBestTime.text = string.Format(_selectedLevelBestTimeFormat, PlayerPrefsManager.Instance.prefUser.levelData[levelId].bestTime);
        _selectedLevelBestAccuracy.text = string.Format(_selectedLevelBestAccuracyFormat, PlayerPrefsManager.Instance.prefUser.levelData[levelId].maxAccuracy);
    }

    public void LoadSelectedLevel()
    {
        _playLevelButton.interactable = false;

        if(levelToLoad == 0)
        {
            _selectedLevelDescription.text = "Select a level to load first!";
            return;
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

}
