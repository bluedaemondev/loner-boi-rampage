using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovement : IMovement
{
    #region PROPERTIES
    private float speed;
    private Rigidbody m_rigidbody;
    private AnalogStickInput input;

    private Vector3 direction;

    private Action<float> onMovementHandler;

    #endregion

    #region CONSTRUCTOR
    public StickMovement(Rigidbody rb, AnalogStickInput stick, float speed = 5f)
    {
        this.speed = speed;
        this.m_rigidbody = rb;
        this.input = stick;
    }
    #endregion

    #region METHODS
    public void Move()
    {
        // adaptacion del stick a coordenadas correctas
        this.direction.x = input.Value.x;
        this.direction.z = input.Value.y;

        // hago el movimiento correspondiente con fixed update
        this.m_rigidbody.MovePosition(m_rigidbody.transform.position + direction * speed * Time.fixedDeltaTime);

        this.onMovementHandler(direction.magnitude);

    }

    public void SubscribeToEndCoroutine(Action handler)
    {
        Debug.Log("Shouldn't use this");
    }
    public void SubscribeOnMoveHandler(Action<float> newHandler)
    {
        onMovementHandler += newHandler;
    }
    #endregion
}
