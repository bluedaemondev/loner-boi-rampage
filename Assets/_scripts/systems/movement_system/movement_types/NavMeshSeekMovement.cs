using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshSeekMovement : IMovement
{
    #region PROPERTIES
    private NavMeshAgent m_agent;
    private Transform m_target;

    private bool shouldFollow;
    private Action onComplete;

    #endregion

    #region CONSTRUCTOR
    public NavMeshSeekMovement(NavMeshAgent agent, Transform target, bool shouldFollow = false)
    {
        this.m_agent = agent;
        this.m_target = target;

        if (shouldFollow)
            this.m_agent.SetDestination(this.m_target.position);

        //SubscribeToEndCoroutine(this.ResetWaypointLoop);
    }

    #endregion

    #region METHODS
    public void Move()
    {

        //if (shouldFollow &&
        //    this.m_agent.pathEndPosition.x == this.m_agent.transform.position.x &&
        //    this.m_agent.pathEndPosition.z == this.m_agent.transform.position.z)
        //{

        //    //Debug.Log(string.Format("path end {0} , position {1} ", m_agent.pathEndPosition, m_agent.transform.position));
        //    if (this.currentWaypoint >= this.waypoints.Count)
        //    {
        //        onComplete?.Invoke();
        //    }
        //}

        if (shouldFollow)
            this.m_agent.SetDestination(m_target.position);

    }

    public void SubscribeToEndCoroutine(Action handler)
    {
        this.onComplete += handler;
    }
    
    #endregion
}
