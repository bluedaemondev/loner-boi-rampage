using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : IState
{

    private FiniteStateMachine fsm;
    private IMovement movement;


    public FleeState(FiniteStateMachine m_fsm)
    {
        this.fsm = m_fsm;
    }



    public void OnStart()
    {
        Debug.Log("Entre en flee");
    }

    public void OnUpdate()
    {
        Debug.Log("Fleeing...");

        // TO DO:
        // tiene un action que cambia por event system
        // si el jugador dispara cerca de mi, empiezo a hacer fleeState
        // sino sigo en mi estado
    }

    public void OnExit()
    {
        Debug.Log("Sali de flee");
        //throw new System.NotImplementedException();
    }
}
