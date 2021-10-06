using UnityEngine;
using Button = UnityEngine.UI.Button;
using SManager = UnityEngine.SceneManagement.SceneManager;

public class MenuButtonUI : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        this.button = GetComponent<Button>();
        this.button.onClick.AddListener(MenuScene);
    }

    private void MenuScene()
    {
        EventManager.ExecuteEvent(Constants.ON_SAVE_PREFS);

        SManager.LoadScene(0);
    }
}