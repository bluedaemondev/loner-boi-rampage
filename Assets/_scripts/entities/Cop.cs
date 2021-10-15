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
    protected ShootAddon shootingAddon;

    [SerializeField]
    protected VictimEnum currentState = VictimEnum.Patrol;


    protected override void Awake()
    {
        base.Awake();

        if(!shootingAddon)
            shootingAddon = GetComponent<ShootAddon>();

        this.gunscript = gunPrefab.GetComponent<Gun>();
        gunscript.shotHelper = this.shootingAddon;


        this.fsm.AddState(VictimEnum.Aiming, new AimingState());
        this.fsm.AddState(VictimEnum.Shooting, new ShootingState(fsm, shootingAddon, gunscript));


        this.fsm.ChangeState(currentState);

        
    }

    protected override void OnDeadHandler()
    {
        base.OnDeadHandler();
        var gun = DropFactory.Instance.pool.GetObject();
        gun.SetPickupStrategy(new GunPickup(gunscript), gunType);

        gun.transform.position = transform.position + Vector3.right;

        Entity.DestroyEntity(this);
    }

}
