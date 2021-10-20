using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : IPickup
{
    private float healthToRecover;

    private Func<float, Health> onPickupGrabbed;

    public HealthPickup(float health)
    {
        this.healthToRecover = health;
    }

    public HealthPickup SetOnGrab(Func<float, Health> onGrabDelegate)
    {
        this.onPickupGrabbed = onGrabDelegate;
        return this;
    }

    public void OnGrabPickup()
    {
        Debug.Log(string.Format("hp {0} pickup grab", this.healthToRecover));
        this.onPickupGrabbed?.Invoke(this.healthToRecover);
        SoundManager.instance.PlayAmbient("healthpickup");
    }
}
