using UnityEngine;
using Button = UnityEngine.UI.Button;
using SManager = UnityEngine.SceneManagement.SceneManager;

public class ReloadSceneButtonUI : MonoBehaviour
{
    Button button;
    [SerializeField] private bool savePrefs;

    private void Awake()
    {
        this.button = GetComponent<Button>();
        this.button.onClick.AddListener(ReloadScene);
    }

    private void ReloadScene()
    {
        if (savePrefs)
            EventManager.ExecuteEvent(Constants.ON_SAVE_PREFS);
        
        SManager.LoadScene(SManager.GetActiveScene().buildIndex);
    }
}
