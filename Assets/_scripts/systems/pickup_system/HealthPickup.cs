using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : IPickup
{
    private float healthToRecover;

    private Func<Health> onPickupGrabbed;
    private Action onPickupSpawn;

    public HealthPickup(float health, Action onSpawn, Func<Health> onGrab)
    {
        this.healthToRecover = health;
        this.onPickupSpawn = onSpawn;
        this.onPickupGrabbed = onGrab;

        this.onPickupSpawn?.Invoke();
    }

    public HealthPickup SetOnGrab(Func<Health> onGrabDelegate)
    {
        this.onPickupGrabbed = onGrabDelegate;
        return this;
    }
    public HealthPickup SetOnSpawn(Action onSpawnDelegate)
    {
        this.onPickupSpawn = onSpawnDelegate;
        return this;
    }

    public void OnGrabPickup()
    {
        Debug.Log("pickup grab");
        this.onPickupGrabbed?.Invoke();
    }
}
