using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickup : IPickup
{
    private int amount;
    private Entity grabber;

    public CashPickup(int amount)
    {
        this.amount = amount;
    }
    public void OnGrabPickup()
    {
        EventManager.ExecuteEvent(Constants.ON_GET_POINTS, amount);
        SoundManager.instance.PlayAmbient("cashpickup");
    }

    public void SetGrabber(GameObject other = null)
    {
        this.grabber = other.GetComponent<Entity>();
    }
}
