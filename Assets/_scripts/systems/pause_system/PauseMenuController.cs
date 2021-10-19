using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Control para menu de pausa. Se encuentra en escena
/// y tiene un objeto hijo con todos los elementos de ui
/// que se activan/desactivan
/// </summary>
public class PauseMenuController : MonoBehaviour
{
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
}
