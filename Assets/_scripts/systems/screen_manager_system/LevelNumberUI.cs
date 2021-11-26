using UnityEngine;

public class LevelNumberUI : MonoBehaviour
{
    UnityEngine.UI.Text container;

    private void Awake()
    {
        this.container = GetComponent<UnityEngine.UI.Text>();
        this.container.text = GameManager.Instance.LoadedLevel.ToString();

    }
}
