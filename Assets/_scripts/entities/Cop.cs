using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : Victim
{
    [SerializeField] protected GameObject gunPrefab;
    [SerializeField] protected PickupType gunType;
    
    [SerializeField]
    protected GameObject gunCurrent;

    [SerializeField]
    protected ShootAddon shootingAddon;

    [SerializeField]
    protected VictimEnum currentState = VictimEnum.Patrol;


    protected override void Awake()
    {
        base.Awake();

        if(!shootingAddon)
            shootingAddon = GetComponent<ShootAddon>();

        //this.gunscript = gunPrefab.GetComponent<Gun>();
        //gunCurrent.GetComponent<Gun>().shotHelper = this.shootingAddon;


        this.fsm.AddState(VictimEnum.Aiming, new AimingState());
        this.fsm.AddState(VictimEnum.Shooting, new ShootingState(fsm, shootingAddon, gunCurrent.GetComponent<Gun>()));


        this.fsm.ChangeState(currentState);
    }

    protected override void OnDeadHandler()
    {
        //base.OnDeadHandler();
        var gun = DropFactory.Instance.pool.GetObject();

        gun.SetPickupStrategy(new GunPickup(gunCurrent), gunType);

        gun.transform.position = transform.position + Vector3.right;
        StartCoroutine(WaitTillNextFrameAndDie());

    }

    IEnumerator WaitTillNextFrameAndDie()
    {
        ToggleAnimatorTrigger("dying");
        GetComponent<Collider>().enabled = false;
        shootingAddon.enabled = false;

        yield return new WaitForSeconds(1f);
        Entity.DestroyEntity(this);

    }

}
