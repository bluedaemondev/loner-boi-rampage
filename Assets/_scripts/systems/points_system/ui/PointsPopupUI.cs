using UnityEngine;
using Text = UnityEngine.UI.Text;

public class PointsPopupUI : MonoBehaviour
{
    [SerializeField] private Text pointsDisplay;
    [SerializeField] private Animation animPopUp;

    [SerializeField] private AudioClip clipOnPopup;

    private static string popupAnimName = "PopupTweenLeft";

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, this.PopUp);
    }
    private void PopUp(params object[] vs)
    {
        this.pointsDisplay.text = string.Format($"$ {0}", vs[0].ToString());
        this.animPopUp.PlayQueued(popupAnimName, QueueMode.CompleteOthers);
    }
}
