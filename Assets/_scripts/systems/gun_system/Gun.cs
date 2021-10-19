using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    // crear clase base para reciclar el addon de disparo en enemigos y player
    //[SerializeField] public IGunner shotHelper;

    [SerializeField] private float timeBetweenShots;
    [SerializeField] protected AudioClip shootSound;

    protected Transform gunpointPivot;

    public float TimeBetweenShots { get => timeBetweenShots; }

    protected void Start()
    {
        gunpointPivot = transform.Find("Gunpoint");
        //if (shotHelper != null)
        //{
            

        //    //shotHelper.SubscribeToOnShoot(this.Fire);

        //    // .sethelper
        //}
    }

    public abstract void Fire();
    public override string ToString()
    {
        return gameObject.name;
    }

}
