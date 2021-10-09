using UnityEngine;
using Button = UnityEngine.UI.Button;
using SManager = UnityEngine.SceneManagement.SceneManager;

public class NextSceneButtonUI : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        this.button = GetComponent<Button>();
        this.button.onClick.AddListener(NextScene);
    }

    private void NextScene()
    {
        EventManager.ExecuteEvent(Constants.ON_SAVE_PREFS);
        var next = SManager.GetActiveScene().buildIndex + 1;
        Debug.Log(SManager.sceneCountInBuildSettings < next);
        if (SManager.sceneCountInBuildSettings < next )
            SManager.LoadScene(next);
        else
            SManager.LoadScene(0);
    }
}
