using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private Transform m_transform;
    private FiniteStateMachine fsm;
    private IMovement movement;

    private List<Transform> waypoints;
    private int currentWaypoint;

    public PatrolState(FiniteStateMachine fsm, Transform transform, List<Transform> waypoints, int currentWP = 0, float speed = 5)
    {
        this.fsm = fsm;
        this.m_transform = transform;
        this.waypoints = waypoints;

        this.currentWaypoint = currentWP;
        this.movement = new FollowMovement(transform, speed);
    }

    public void OnStart()
    {
        Debug.Log("Entre en patrol");
    }

    public void OnUpdate()
    {
        Debug.Log("Patroling...");

        if (waypoints != null && waypoints.Count > 0)
            ChaseWaypoint();
        else
            fsm.ChangeState(VictimEnum.Idle);

        //if (movement != null)
        //    /*movement.Move(*/ChaseWaypoint()/*)*/;


    }

    public void OnExit()
    {
        Debug.Log("Sali de patrol");
        //throw new System.NotImplementedException();
    }

    private Vector3 ChaseWaypoint()
    {
        Vector3 dir = this.waypoints[this.currentWaypoint].position - this.m_transform.position;
        dir.y = 0;

        this.m_transform.forward = dir;

        this.m_transform.position += this.m_transform.forward * 5 * Time.deltaTime;

        if (dir.magnitude < 0.1f)
        {
            this.currentWaypoint++;
            if (this.currentWaypoint > this.waypoints.Count - 1)
            {
                this.currentWaypoint = 0;
                this.fsm.ChangeState(VictimEnum.Idle);
            }
        }
        //Debug.Log(dir);
        

        return dir;
    }
}
