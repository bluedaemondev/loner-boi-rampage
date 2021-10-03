using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private AnalogStickInput movementInput;
    [SerializeField] private IMovement movement;

    [SerializeField] private Rigidbody m_rigidbody;
    void Awake()
    {
        this.HealthSystem = new Health(100);
        this.movement = new StickMovement(this.m_rigidbody);
    }

    private void FixedUpdate()
    {
        movement.Move(movementInput.Value);
    }
}
