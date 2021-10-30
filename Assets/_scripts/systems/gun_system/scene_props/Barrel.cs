using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Barrel : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float health_ammount = 150;
    protected Animator m_animator;
    protected string die_trigger = "dying";
    protected string damaged_trigger = "damaged";
    protected Health health;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = new Health(health_ammount);
    }

    public abstract void OnExplode();

    public abstract void OnTakeDamage(float ammount);
}
