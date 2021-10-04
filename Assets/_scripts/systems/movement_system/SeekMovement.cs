using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekMovement : IMovement
{
    private Rigidbody m_rigidbody;
    private float speed;
    private float maxForce;

    private Vector3 _velocity;

    private Vector3 desiredPos;
    private Vector3 steering;

    public SeekMovement(Rigidbody rigidbody, float maxSpeed, float maxForce)
    {
        this.m_rigidbody = rigidbody;
        this.speed = maxSpeed;
        this.maxForce = maxForce;

        this._velocity = Vector3.zero;
    }
    public void Move(Vector3 target)
    {
        desiredPos = target - m_rigidbody.transform.position;
        desiredPos.Normalize();
        desiredPos.y = 0;

        desiredPos *= speed;


        steering = desiredPos - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        AddForce(steering);
    }
    void AddForce(Vector3 f)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + f, speed);

        m_rigidbody.MovePosition(desiredPos * Time.fixedTime);
    }
}
