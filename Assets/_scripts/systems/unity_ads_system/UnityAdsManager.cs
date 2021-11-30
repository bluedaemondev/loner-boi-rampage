using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAdsManager : MonoBehaviour
{
    private static UnityAdsManager _instance;
    public static UnityAdsManager Instance
    {
        get
        {
            return _instance;
        }
    }

    //[SerializeField]
    private string ad_identifier_android = "4479229";
    //[SerializeField]
    private string ad_identifier_ios = "4479228";
    
    private string _gameId;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? ad_identifier_ios
            : ad_identifier_android;

        Advertisement.Initialize(_gameId, true);
    }
}
