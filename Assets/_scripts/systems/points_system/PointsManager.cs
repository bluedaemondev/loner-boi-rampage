using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int totalPoints;
    private int maxPoints;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_LOAD_PREFS, this.SetMaxPoints);
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, this.AddPoints);
    }

    private void SetMaxPoints(params object[] vs)
    {
        this.maxPoints = (int)vs[0];
    }

    private void AddPoints(params object[] vs)
    {
        this.totalPoints += (int)vs[0];
    }
}
