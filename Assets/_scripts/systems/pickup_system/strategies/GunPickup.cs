using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : IPickup
{
    private GameObject gunToGrab;

    public GunPickup(GameObject prefabRef)
    {
        this.gunToGrab = MonoBehaviour.Instantiate(prefabRef);
    }

    public void OnGrabPickup()
    {
        SoundManager.instance.PlayEffect("gunpickup");
        EventManager.ExecuteEvent(Constants.ON_WEAPON_CHANGE, gunToGrab.name, gunToGrab);
    }
}
