using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Health HealthSystem;
    [SerializeField] protected Animator m_animator;
    [SerializeField] protected IMovement default_movement;

    [SerializeField] protected Rigidbody m_rigidbody;

    protected virtual void Awake()
    {
        this.HealthSystem = new Health(100);
    }
}
