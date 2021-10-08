using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : Victim
{
    [SerializeField] float healPower;

    protected override void Awake()
    {
        base.Awake();
        this.fsm.ChangeState(VictimEnum.Idle);
    }
    protected override void OnDeadHandler()
    {
        var medkit = DropFactory.Instance.pool.GetObject();
        medkit.SetPickupStrategy(new HealthPickup(healPower), PickupType.Health);
        medkit.transform.position = transform.position;

        Entity.DestroyEntity(this);
    }
}
