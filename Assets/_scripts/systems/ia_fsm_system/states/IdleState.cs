using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private FiniteStateMachine fsm;
    private IMovement movement;


    private float timeInState = 5;
    private float currentTime = 0;


    public IdleState(FiniteStateMachine m_fsm)
    {
        this.fsm = m_fsm;
    }



    public void OnStart()
    {
        Debug.Log("Entre en idle");
    }

    public void OnUpdate()
    {
        //Debug.Log("Idling...");
        this.currentTime += Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.F1))
        if (currentTime >= timeInState)
        {
            this.currentTime = 0;
            fsm.ChangeState(VictimEnum.Patrol);
        }

        // TO DO:
        // tiene un action que cambia por event system
        // si el jugador dispara cerca de mi, empiezo a hacer fleeState
        // sino sigo en mi estado
    }

    public void OnExit()
    {
        Debug.Log("Sali de idle");
        //throw new System.NotImplementedException();
    }
}
