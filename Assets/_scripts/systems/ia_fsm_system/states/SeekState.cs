using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekState : IState
{
    private FiniteStateMachine fsm;
    private IMovement movement;

    public SeekState(FiniteStateMachine fsm, IMovement movement)
    {
        this.fsm = fsm;
        this.movement = movement;
    }

    public void OnExit()
    {
        //throw new System.NotImplementedException();
    }

    public void OnStart()
    {
        //throw new System.NotImplementedException();

    }

    public void OnUpdate()
    {
        this.movement.Move();

        //throw new System.NotImplementedException();
    }
}
