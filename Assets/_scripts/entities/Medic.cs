using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : Victim
{
    [SerializeField] float healPower;
    protected override void OnDeadHandler()
    {
        var medkit = DropFactory.Instance.pool.GetObject();
        medkit.SetPickupStrategy(new HealthPickup(healPower), PickupType.Health);
    }
}
