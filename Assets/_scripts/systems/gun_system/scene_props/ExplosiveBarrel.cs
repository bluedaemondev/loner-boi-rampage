using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : Barrel
{
    [SerializeField]
    private GameObject explosion;

    public override void OnExplode()
    {
        explosion.gameObject.SetActive(true);
        this.m_animator.SetTrigger(die_trigger);
    }

    public override void OnTakeDamage(float ammount)
    {
        this.health.TakeDamage(ammount);
        this.m_animator.SetTrigger(damaged_trigger);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_animator = GetComponent<Animator>();
        this.health.SubscribeDeadHandler(OnExplode);
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

}
