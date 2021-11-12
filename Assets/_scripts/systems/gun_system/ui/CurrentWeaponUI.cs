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
        this.textContainer.text = vs[0].ToString(); 
    }
}
