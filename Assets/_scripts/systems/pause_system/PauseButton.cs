using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PauseButton : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        this.button = GetComponent<Button>();
    }
    public void PauseGame()
    {
        //PauseMenuController.Instance.TogglePauseState();
        ScreenManager.Instance?.Push("Pause_Screen");
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        ScreenManager.Instance.lastResult = "Back";
        ScreenManager.Instance.Pop();
    }
}
