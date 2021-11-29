using UnityEngine;
using Button = UnityEngine.UI.Button;

public enum AdType { 
    Interstitial,
    RewardedInterstitial,
    Banner
}

public class ShowAdButton : MonoBehaviour
{
    [SerializeField] AdType _type;
    private Button _btn;


    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        switch (_type) {
            case AdType.Banner:
                DisplayBannerAd();
                break;
            case AdType.Interstitial:
                DisplayInterstitialAd();
                break;
            case AdType.RewardedInterstitial:
                DisplayRewardedAd();
                break;
        }

    }
    void DisplayInterstitialAd()
    {
        ScreenManager.Instance.Push("Interstitial_Screen");
    }
    void DisplayBannerAd()
    {
        //UnityAdsManager.Instance.ShowBanner();
        Debug.Log("Display banner ad in screen"); 

    }
    void DisplayRewardedAd()
    {
        ScreenManager.Instance.Push("Rewarded_Interstitial_Screen");

    }
}
