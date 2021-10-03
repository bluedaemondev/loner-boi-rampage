using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    // crear clase base para reciclar el addon de disparo en enemigos y player
    [SerializeField] protected ShooterAnalogStickAddon shotHelper;

    [SerializeField] protected float timeBetweenShots;
    [SerializeField] protected AudioClip shootSound;

    protected Transform gunpointPivot;

    protected void OnEnable()
    {
        if (shotHelper != null)
        {
            gunpointPivot = transform.Find("Gunpoint");
            
            shotHelper.SetGunshotInterval(timeBetweenShots);
            shotHelper.SubscribeToOnShoot(Fire);
        }
    }

    protected abstract void Fire();

}
