using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : Entity
{
    protected override void Awake()
    {
        base.Awake();
        default_movement = new SeekMovement(m_rigidbody, 5, 5);
    }
    private void FixedUpdate()
    {
        default_movement.Move(FindObjectOfType<Player>().transform.position);
    }

}
