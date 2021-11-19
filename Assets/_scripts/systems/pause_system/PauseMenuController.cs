using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;
/// <summary>
/// Control para menu de pausa. Se encuentra en escena
/// y tiene un objeto hijo con todos los elementos de ui
/// que se activan/desactivan
/// </summary>
public class PauseMenuController : MonoBehaviour, IScreen
{
    [SerializeField]
    Button[] content;

    public static PauseMenuController Instance
    {
        get
        {
            return _instance;
        }
    }
    static PauseMenuController _instance;

    public GameObject pauseWindowContainer;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }

        _instance = this;
    }

    public void TogglePauseState()
    {
        bool shouldPause = !pauseWindowContainer.activeSelf;
        // pause on => shouldPause = false

        pauseWindowContainer.SetActive(shouldPause);
        PauseManager.instance.TogglePause(shouldPause);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constants.MAIN_MENU_BUILD_IDX);
    }

    public void Activate()
    {
        foreach(var item in content)
        {
            item.interactable = true;
        }
    }

    public void Deactivate()
    {
        foreach (var item in content)
        {
            item.interactable = false;
        }
    }

    public string Free()
    {
        this.gameObject.SetActive(false);
        return "Pause Screen Disabled";
    }
}
