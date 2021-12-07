using UnityEngine;
using Button = UnityEngine.UI.Button;
using SManager = UnityEngine.SceneManagement.SceneManager;

public class MenuButtonUI : MonoBehaviour
{
    Button button;
    [SerializeField] bool autoLoad = true;
    private void Awake()
    {
        this.button = GetComponent<Button>();
        if (autoLoad)
            this.button.onClick.AddListener(MenuScene);
    }

    public void MenuScene()
    {
        //EventManager.ExecuteEvent(Constants.ON_SAVE_PREFS);

        SManager.LoadScene(Constants.MAIN_MENU_BUILD_IDX);
    }
}