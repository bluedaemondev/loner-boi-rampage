using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Health HealthSystem;
    [SerializeField] protected Animator m_animator;
}
