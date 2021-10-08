using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : IMovement
{
    private float speed;
    private Transform m_transform;
    private Transform target;

    private System.Action onReach;


    public FollowMovement(Transform transform, float speed = 6)
    {
        this.m_transform = transform;
        this.speed = speed;
    }

    public void Move()
    {
        this.m_transform.position += (target.position - this.m_transform.position).normalized * speed * Time.deltaTime;
    }

    public void SubscribeToEndCoroutine(Action handler)
    {
        onReach += handler;
    }
}
