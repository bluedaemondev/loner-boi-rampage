using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickup : IPickup
{
    private int amount;
    //private Mesh mesh;

    public CashPickup(int amount)
    {
        this.amount = amount;
    }
    public void OnGrabPickup()
    {
        EventManager.ExecuteEvent(Constants.ON_GET_POINTS, amount);
    }

}
