using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshWaypointMovement : IMovement
{
    #region PROPERTIES
    private NavMeshAgent m_agent;
    private List<Vector3> waypoints;
    private int currentWaypoint;

    private Action onLoopComplete;

    #endregion

    #region CONSTRUCTOR
    public NavMeshWaypointMovement(NavMeshAgent agent, List<Vector3> nodes)
    {
        this.m_agent = agent;
        this.currentWaypoint = 0;

        this.waypoints = new List<Vector3>();

        // agrego en donde estoy para loopear
        this.waypoints.Add(this.m_agent.transform.position);
        this.waypoints.AddRange(nodes);

        this.m_agent.SetDestination(this.waypoints[currentWaypoint]);

        SubscribeToEndCoroutine(this.ResetWaypointLoop);
    }

    #endregion

    #region METHODS
    public void Move()
    {

        if (this.m_agent.pathEndPosition.x == this.m_agent.transform.position.x &&
            this.m_agent.pathEndPosition.z == this.m_agent.transform.position.z)
        {

            //Debug.Log(string.Format("path end {0} , position {1} ", m_agent.pathEndPosition, m_agent.transform.position));
            this.currentWaypoint++;
            if (this.currentWaypoint >= this.waypoints.Count)
            {
                onLoopComplete?.Invoke();
            }
        }

        this.m_agent.SetDestination(waypoints[currentWaypoint]);

    }

    public void SubscribeToEndCoroutine(Action handler)
    {
        this.onLoopComplete += handler;
    }
    public void ResetWaypointLoop()
    {
        this.currentWaypoint = 0;
    }
    #endregion
}
