using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IScreen
{
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    static GameManager _instance;

    public SoundLibrary GameSounds;

    public Camera mainCamera;

    public Transform player;

    public static int TOTAL_VICTIMS = 0;
    public int LoadedLevel = 0;

    void OnLevelWasLoaded(int level)
    {
        LoadedLevel = level;
    }

    private void Awake()
    {
        _instance = this;

        EventManager.ResetEvents();

        EventManager.SubscribeToEvent(Constants.ON_WIN_CONDITION, WinScreenDisplay);
        EventManager.SubscribeToEvent(Constants.ON_DEFEAT_CONDITION, DefeatScreenDisplay);

        TOTAL_VICTIMS = 0;

        mainCamera = Camera.main;

    }
    private void Start()
    {
        ScreenManager.Instance.Push(this);
    }

    public void Activate()
    {
        Time.timeScale = 1;
    }

    public void Deactivate()
    {
        Time.timeScale = 0;
    }

    public string Free()
    {
        Time.timeScale = 0;

        return "Game Screen Disabled";
    }
    private void WinScreenDisplay(params object[] vs)
    {
        ScreenManager.Instance.Push("Win_Screen");
    }
    private void DefeatScreenDisplay(params object[] vs)
    {
        ScreenManager.Instance.Push("Defeat_Screen");
    }

    #region DEBUGGING
    //Health healthSystemTesting;
    // Start is called before the first frame update
    //void Start()
    //{
    //healthSystemTesting = FindObjectOfType<Player>().HealthSystem;
    //}
    //public void Damage()
    //{
    //    this.healthSystemTesting.TakeDamage(10);
    //    Debug.Log(this.healthSystemTesting.GetHealthPercentaje());
    //}
    //public void Heal()
    //{
    //    this.healthSystemTesting.Heal(10);
    //    Debug.Log(this.healthSystemTesting.GetHealthPercentaje());
    //}
    #endregion
}
