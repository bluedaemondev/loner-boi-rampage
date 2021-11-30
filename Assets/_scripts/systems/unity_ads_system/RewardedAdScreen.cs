using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdScreen : MonoBehaviour, IScreen
{
    private string ad_unit_id_android = "Interstitial_Android";
    private string ad_unit_id_ios = "Interstitial_iOS";

    private string unit_id;

    //private float time_refresh = 0.25f;
    //YieldInstruction awaiter;

    private void Awake()
    {
        //awaiter = new WaitForSeconds(time_refresh);
        unit_id = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? ad_unit_id_ios
                : ad_unit_id_android;
    }

    public void Activate()
    {
        LoadAd();
    }

    public void Deactivate()
    {
        ScreenManager.Instance.Pop();
    }

    public string Free()
    {
        this.gameObject.SetActive(false);
        return "Rewarded AD Screen Disabled";
    }

    private void LoadAd()
    {
        Debug.Log("Loading Ad: " + unit_id);
        StartCoroutine(LoadAdDeferred());
    }
    private IEnumerator LoadAdDeferred()
    {
        while (!Advertisement.IsReady(unit_id))
        {
            yield return null;
        }
        Debug.Log("Done loading " + unit_id);
        Advertisement.Show(unit_id, new ShowOptions { resultCallback = CheckResult });
    }
    private void CheckResult (ShowResult callbackResult)
    {
        switch (callbackResult)
        {
            case ShowResult.Finished:
                Debug.Log("finished ad");
                // si completa el ad, duplica el puntaje
                EventManager.ExecuteEvent(Constants.ON_GET_POINTS, PointsManager.Instance.TotalPoints);
                break;
            case ShowResult.Skipped:
                Debug.Log("skipped ad");
                // si skippea , +0.5
                EventManager.ExecuteEvent(Constants.ON_GET_POINTS, Mathf.FloorToInt(PointsManager.Instance.TotalPoints / 2f));

                break;
            case ShowResult.Failed:
                Debug.Log("failed ad");
                
                // si fallo, recarga
                LoadAd();
                break;
        }
    }

}
