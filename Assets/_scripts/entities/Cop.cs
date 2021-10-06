using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : Victim
{
    [SerializeField] protected GameObject gunPrefab;
    [SerializeField] protected PickupType gunType;

    protected Gun gunscript;

    [SerializeField]
    protected IGunner shootingAddon;

    protected override void Awake()
    {
        base.Awake();

        this.fsm.AddState(VictimEnum.Aiming, new AimingState());
        this.fsm.AddState(VictimEnum.Shooting, new ShootingState());

        this.gunscript = gunPrefab.GetComponent<Gun>();
    }

    protected override void OnDeadHandler()
    {
        base.OnDeadHandler();
        var gun = DropFactory.Instance.pool.GetObject();
        gun.SetPickupStrategy(new GunPickup(gunscript), gunType);

        gun.transform.position = transform.position;

        Entity.DestroyEntity(this);
    }

}
