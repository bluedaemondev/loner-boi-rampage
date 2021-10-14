using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IState
{
    FiniteStateMachine _fsm;
    ShootAddon addon;
    Gun gun;

    float energyForShooting = 30;
    float energyConsumedPerShoot = 10;

    public ShootingState(FiniteStateMachine fsm, ShootAddon shootAddon, Gun gun, int bulletsPerBurst = 3)
    {
        this._fsm = fsm;
        this.addon = shootAddon;

        energyForShooting = bulletsPerBurst * 10;
        this.gun = gun;

        shootAddon.SubscribeToOnShoot(this.ShootLogic);
    }

    public void OnExit()
    {
        Debug.Log("Stop shooting");
    }

    public void OnStart()
    {


    }

    void ShootLogic()
    {
        //this.addon.StartFire();
        gun.Fire();
        energyForShooting -= energyConsumedPerShoot;

        Debug.Log("firing");

        if (energyForShooting <= 0)
        {
            Debug.Log("changing");
            this.energyForShooting = 30;
            _fsm.ChangeState(VictimEnum.Patrol);
        }
    }

    float timerMultishoot = 0;
    float maxTimer = 0.7f;

    public void OnUpdate()
    {
        
        if((timerMultishoot += Time.deltaTime) >= maxTimer)
        {
            _fsm.ChangeState(VictimEnum.Idle);
        }

    }

}
