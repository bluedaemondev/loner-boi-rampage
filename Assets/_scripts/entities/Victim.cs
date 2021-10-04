using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : Entity
{
    protected FiniteStateMachine fsm;
    [SerializeField]
    protected List<Transform> waypointsToPatrol;

    protected override void Awake()
    {
        base.Awake();

        this.fsm = new FiniteStateMachine();

        this.fsm.AddState(VictimEnum.Idle, new IdleState(this.fsm));
        this.fsm.AddState(VictimEnum.Patrol, new PatrolState(this.fsm, this.transform, this.waypointsToPatrol));
        this.fsm.AddState(VictimEnum.Fleeing, new FleeState(this.fsm));

        this.fsm.ChangeState(VictimEnum.Idle);

        //default_movement = new SeekMovement(m_rigidbody, 5, 5);
    }
    private void Update()
    {
        this.fsm.OnUpdate();
    }

}
