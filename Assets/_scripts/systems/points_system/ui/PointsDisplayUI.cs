using System.Collections;
using UnityEngine;
using Text = UnityEngine.UI.Text;
public class PointsDisplayUI : MonoBehaviour
{
    [SerializeField] private Text pointsDisplay;

    public string id;

    private int currentDisplay;
    private int maxDisplayTarget;

    [SerializeField]
    private float timeTweener = 0.02f;

    private YieldInstruction awaiter;
    private Coroutine crTweener;


    void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, this.MaxUp);
        awaiter = new WaitForSeconds(timeTweener);
    }
    private void MaxUp(params object[] vs)
    {
        this.maxDisplayTarget += (int)vs[0];
        if (crTweener == null)
            crTweener = StartCoroutine(MaxUpTween());
    }

    private IEnumerator MaxUpTween()
    {
        while (currentDisplay < maxDisplayTarget)
        {
            currentDisplay += 1;
            pointsDisplay.text = 
                string.Format(LangManager.Instance != null ? LangManager.Instance.GetTranslate(id) + ":\n$ {0}" : "$ {0}", currentDisplay);
            yield return awaiter;
        }

        this.crTweener = null;
    }
}
