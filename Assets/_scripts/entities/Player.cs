using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private AnalogStickInput movementInput;

    protected override void Awake()
    {
        base.Awake();
        this.default_movement = new StickMovement(this.m_rigidbody);
    }
    
    private void FixedUpdate()
    {
        default_movement.Move(movementInput.Value);
    }
}
