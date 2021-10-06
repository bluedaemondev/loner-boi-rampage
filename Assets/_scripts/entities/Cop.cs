using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : Victim
{
    [SerializeField] protected GameObject gunPrefab;

    protected override void OnDeadHandler()
    {
        base.OnDeadHandler();
        var gun = DropFactory.Instance.pool.GetObject();
        gun.SetPickupStrategy(new GunPickup(gunPrefab.GetComponent<Pistol>()), PickupType.Pistol);

        gun.transform.position = transform.position;

        Entity.DestroyEntity(this);
    }
}
