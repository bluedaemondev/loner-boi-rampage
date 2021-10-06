using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : Entity
{
    protected FiniteStateMachine fsm;
    [SerializeField]
    protected List<Transform> waypointsToPatrol;
    [SerializeField]
    protected int maxPickupsDrop;

    protected override void Awake()
    {
        base.Awake();

        this.fsm = new FiniteStateMachine();

        this.fsm.AddState(VictimEnum.Idle, new IdleState(this.fsm));
        this.fsm.AddState(VictimEnum.Patrol, new PatrolState(this.fsm, this.transform, this.waypointsToPatrol));
        this.fsm.AddState(VictimEnum.Fleeing, new FleeState(this.fsm));

        this.fsm.ChangeState(VictimEnum.Idle);

        this.HealthSystem.SubscribeDeadHandler(this.OnDeadHandler);
        //default_movement = new SeekMovement(m_rigidbody, 5, 5);
    }
    protected virtual void Update()
    {
        this.fsm.OnUpdate();
    }

    protected virtual void OnDeadHandler()
    {
        int amountPicked = Random.Range(1, maxPickupsDrop);
        var lDrop = DropFactory.Instance.pool.GetObject(amountPicked);

        for (int item = 0; item < amountPicked; item++)
        {
            lDrop[item] = lDrop[item].SetPickupStrategy(new CashPickup(Random.Range(maxPickupsDrop / 3, maxPickupsDrop + 1)), PickupType.Cash);
        }
    }

}
