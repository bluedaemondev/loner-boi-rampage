using UnityEngine;
using Button = UnityEngine.UI.Button;

public class ShowAdButton : MonoBehaviour
{
    [SerializeField] AdType _type;
    private Button _btn;
    [SerializeField] bool _deactivateOnPress = true;

    void Awake()
    {
        _btn = GetComponent<Button>();
        switch (_type)
        {
            case AdType.Banner:
                _btn.onClick.AddListener(DisplayBannerAd);
                break;
            case AdType.Interstitial:
                _btn.onClick.AddListener(DisplayInterstitialAd);
                break;
            case AdType.RewardedInterstitial:
                _btn.onClick.AddListener(DisplayRewardedAd);
                break;
        }

        if (_deactivateOnPress)
            _btn.onClick.AddListener(DeactivateButton);

    }
    void DeactivateButton()
    {
        this._btn.interactable = false;
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
        //ScreenManager.Instance.Push("Rewarded_Interstitial_Screen");
        Debug.Log("Rewarded interstitial Placeholder");
    }
}
