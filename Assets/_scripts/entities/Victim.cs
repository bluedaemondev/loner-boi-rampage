using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Victim : Entity
{
    public GameObject corpsePrefab;

    protected FiniteStateMachine fsm;
    [SerializeField, InspectorName("Nodes to reach")]
    protected List<Transform> waypointsToPatrol;

    [SerializeField]
    protected NavMeshAgent m_agent;
    protected override void Awake()
    {
        base.Awake();

        this.fsm = new FiniteStateMachine();

        this.fsm.AddState(VictimEnum.Idle, new IdleState(this.fsm));
        this.fsm.AddState(VictimEnum.Patrol, new PatrolState(this.fsm, new NavMeshWaypointMovement(this.m_agent, this.waypointsToPatrol.Select(wp => wp.position).ToList())));
        //this.fsm.AddState(VictimEnum.Fleeing, new FleeState(this.fsm));
        this.fsm.AddState(VictimEnum.Chasing, new SeekState(this.fsm, new NavMeshSeekMovement(m_agent, Player != null ? Player.transform : FindObjectOfType<Player>().transform, false)));

        this.fsm.ChangeState(VictimEnum.Patrol);

        this.HealthSystem.SubscribeDeadHandler(this.OnDeadHandler);
        //default_movement = new SeekMovement(m_rigidbody, 5, 5);
    }
    protected virtual void Start()
    {
        GameManager.TOTAL_VICTIMS++;
        //Debug.Log(this.gameObject.name);
    }

    protected virtual void Update()
    {
        this.fsm.OnUpdate();
    }

    protected virtual void OnDeadHandler()
    {

        int amountPicked = Random.Range(1, 4);

        for (int item = 0; item < amountPicked; item++)
        {
            var lDrop = DropFactory.Instance.pool.GetObject();
            lDrop.SetPickupStrategy(new CashPickup(Constants.CASH_DEFAULT_PICKUP), PickupType.Cash);

            lDrop.transform.position = transform.position;
        }

        if(corpsePrefab)
        {
            Instantiate(corpsePrefab, transform.position + Vector3.down, Quaternion.Euler(Random.Range(0, 360), 0 , 0),null);
        }
        Entity.DestroyEntity(this);
    }



}
