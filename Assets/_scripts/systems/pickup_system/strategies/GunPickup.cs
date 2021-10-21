using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : IPickup
{
    private GameObject gunToGrab;
    private Entity grabber;

    public GunPickup(GameObject prefabRef)
    {
        this.gunToGrab = Object.Instantiate(prefabRef);
    }

    public void OnGrabPickup()
    {
        SoundManager.instance.PlayEffect("gunpickup");
        EventManager.ExecuteEvent(Constants.ON_WEAPON_CHANGE, gunToGrab.name, gunToGrab);
    }

    public void SetGrabber(GameObject other = null)
    {
        grabber = other.GetComponent<Entity>();
    }
}
