using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance
    {
        get
        {
            return _instance;
        }
    }

    static PointsManager _instance;

    public int TotalPoints { get; private set; }
    private int maxPointsPref;

    // bulletsShot-killerBullets
    private float bulletsShot = 0;
    private float killerBullets = 0;

    // porcentual total de accuracy
    public float Accuracy { get { return killerBullets * 100 / Mathf.Max(1 , bulletsShot); } }
    public float AccuracyBonus { get { return Accuracy * pointsAddedByAccuracy; } }
    public float HealthBonus { get { return pointsBonusHealth * Entity.Player.Health; } }
    public float TimeBonus { get {return Mathf.Min(basePointsTime - (timeSinceLevelLoad * pointsSubstractedByTime), 0); } }
    public float DestructionBonus { get { return Mathf.Min(basePointsTime - (timeSinceLevelLoad * pointsSubstractedByTime), 0); } }


    private float timeSinceLevelLoad = 0;
    private float pointsAddedByAccuracy = 5;
    private float pointsSubstractedByTime = 2;
    private float pointsBonusHealth = 5;
    private float basePointsTime = 2000;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }

        _instance = this;
    }
    
    private void Update()
    {
        timeSinceLevelLoad += Time.deltaTime;
    }
    void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_LOAD_PREFS, this.SetMaxPoints);
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, this.AddPoints);
        EventManager.SubscribeToEvent(Constants.ON_GUN_SHOOT, this.AddBulletShot);
    }

    private void SetMaxPoints(params object[] vs)
    {
        if(((Prefs)vs[0]).levelData != default)
            this.maxPointsPref = ((Prefs)vs[0]).levelData[0].maxPoints;
    }

    private void AddPoints(params object[] vs)
    {
        this.TotalPoints += (int)vs[0];
    }
    private void AddBulletShot(params object[] vs)
    {
        this.bulletsShot++;
    }
    private void AddAccurateShot(params object[] vs)
    {
        this.killerBullets++;
    }
    

}
