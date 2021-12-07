using UnityEngine;
using Button = UnityEngine.UI.Button;


public class SavePointsProfileButtonUI : MonoBehaviour
{
    Button _btn;

    private void Awake()
    {
        _btn = GetComponent<Button>();
        //_btn.onClick.AddListener(SaveLevelData);
    }
    // Start is called before the first frame update
    //void Start()
    //{
            
    //}
    public void SaveLevelData()
    {
        int currentLevelIndex = PlayerPrefsManager.Instance.prefUser.levelData.FindIndex(lvl => lvl.level == GameManager.Instance.LoadedLevel);

        PlayerPrefsManager.Instance.prefUser.levelData[currentLevelIndex].maxAccuracy = Mathf.Max(PlayerPrefsManager.Instance.prefUser.levelData[currentLevelIndex].maxAccuracy,PointsManager.Instance.Accuracy);
        PlayerPrefsManager.Instance.prefUser.levelData[currentLevelIndex].bestTime = Mathf.Min(PlayerPrefsManager.Instance.prefUser.levelData[currentLevelIndex].bestTime, PointsManager.Instance.TimeSinceLevelLoad);
        PlayerPrefsManager.Instance.prefUser.levelData[currentLevelIndex].maxPoints = Mathf.Max(PlayerPrefsManager.Instance.prefUser.levelData[currentLevelIndex].maxPoints, (int)PointsManager.Instance.GetTotal());

        PlayerPrefsManager.Instance.StartCoroutine(PlayerPrefsManager.Instance.SavePrefs<Prefs>());

    }
}
