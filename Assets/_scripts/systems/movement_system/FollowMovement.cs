using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : IMovement
{
    private float speed;
    private Transform m_transform;
    
    public FollowMovement(Transform transform, float speed = 6)
    {
        this.m_transform = transform;
        this.speed = speed;
    }

    public void Move(Vector3 target)
    {
        this.m_transform.position += (target - this.m_transform.position).normalized * speed * Time.deltaTime;
    }
}
