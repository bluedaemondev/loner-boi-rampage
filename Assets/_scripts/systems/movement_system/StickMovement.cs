using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovement : IMovement
{
    #region PROPERTIES
    private float speed;
    private Rigidbody m_rigidbody;

    private Vector3 direction;
    #endregion

    #region CONSTRUCTOR
    public StickMovement(Rigidbody rb, float speed = 5f)
    {
        this.speed = speed;
        this.m_rigidbody = rb;
    }
    #endregion

    #region METHODS
    public void Move(Vector3 target)
    {
        // adaptacion del stick a coordenadas correctas
        this.direction.x = target.x;
        this.direction.z = target.y;

        // hago el movimiento correspondiente con fixed update
        this.m_rigidbody.MovePosition(m_rigidbody.transform.position + direction * speed * Time.fixedDeltaTime);
    }
    #endregion
}
