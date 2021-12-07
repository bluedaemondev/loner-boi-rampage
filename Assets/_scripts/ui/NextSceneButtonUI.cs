using UnityEngine;
using Button = UnityEngine.UI.Button;
using SManager = UnityEngine.SceneManagement.SceneManager;

public class NextSceneButtonUI : MonoBehaviour
{
    Button button;
    [SerializeField] bool autoLoad = true;
    private void Awake()
    {
        this.button = GetComponent<Button>();
        if (autoLoad)
            this.button.onClick.AddListener(NextScene);
    }

    public void NextScene()
    {
        EventManager.ExecuteEvent(Constants.ON_SAVE_PREFS);
        var next = SManager.GetActiveScene().buildIndex + 1;

        //Debug.Log(SManager.sceneCountInBuildSettings);
        //Debug.Log(next + 1);

        if (next + 1 <= SManager.sceneCountInBuildSettings)
            SManager.LoadScene(next);
        else
            SManager.LoadScene(0);
    }
}
