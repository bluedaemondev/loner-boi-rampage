using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    private void Awake()
    {
        EventManager.ResetEvents();
        
        TOTAL_VICTIMS = 0;

        mainCamera = Camera.main;
    }
    void Start()
    {
        _instance = this;
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
