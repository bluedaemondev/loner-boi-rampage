using UnityEngine;
using Text = UnityEngine.UI.Text;

public class RewardTextUI : MonoBehaviour
{
    private Text container;

    private void Awake()
    {
        container = GetComponent<Text>();
    }

    void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, UpdateText);
    }

    void UpdateText(params object[] vs)
    {
        container.text = "$ " + vs[0].ToString();
    }
}
