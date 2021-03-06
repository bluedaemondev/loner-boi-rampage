using UnityEngine;
using Text = UnityEngine.UI.Text;

public class CurrentWeaponUI : MonoBehaviour
{
    [SerializeField] private Text textContainer;

    // Start is called before the first frame update
    private void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_WEAPON_CHANGE, this.SetTextInfo);
    }
    private void SetTextInfo(params object[] vs)
    {
        print(vs[0].ToString());
        if (LangManager.Instance)
        {
            string trns = LangManager.Instance.GetTranslate(vs[0].ToString());
            this.textContainer.text = trns != string.Empty ? trns : textContainer.text;
        }
    }
}
