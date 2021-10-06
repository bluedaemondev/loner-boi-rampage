using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : Entity
{
    public static int TOTAL_VICTIMS = 0;

    protected FiniteStateMachine fsm;
    [SerializeField]
    protected List<Transform> waypointsToPatrol;
    [SerializeField, Header("Max cash")]
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
    protected virtual void Start()
    {
        TOTAL_VICTIMS++;
        Debug.Log(this.gameObject.name);
    }

    protected virtual void Update()
    {
        this.fsm.OnUpdate();
    }

    protected virtual void OnDeadHandler()
    {

        int amountPicked = Random.Range(1, 4);
        var lDrop = DropFactory.Instance.pool.GetObject(amountPicked);

        for (int item = 0; item < amountPicked; item++)
        {
            lDrop[item] = lDrop[item].SetPickupStrategy(new CashPickup(Random.Range(maxPickupsDrop / 3, maxPickupsDrop + 1)), PickupType.Cash);
            lDrop[item].transform.position = transform.position;
        }

        Entity.DestroyEntity(this);
    }

}
