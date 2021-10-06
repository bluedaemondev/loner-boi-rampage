using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : IPickup
{
    private Gun gunToGrab;

    public GunPickup(Gun prefabRef)
    {
        this.gunToGrab = prefabRef;
    }

    public void OnGrabPickup()
    {
        throw new System.NotImplementedException();
    }
}
