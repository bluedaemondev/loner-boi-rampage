using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PauseButton : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        this.button = GetComponent<Button>();
        this.button.onClick.AddListener(PauseGame);
    }
    private void PauseGame()
    {
        PauseMenuController.Instance.TogglePauseState();
    }
}
