using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Health HealthSystem;

    [SerializeField] protected HealthBar health_bar;
    [SerializeField] protected Animator m_animator;
    [SerializeField] protected IMovement default_movement;


    protected virtual void Awake()
    {
        this.HealthSystem = new Health(100);
        this.health_bar.SetUpLifeBar(this.HealthSystem);
    }

    public virtual void TakeDamage(float damage)
    {
        this.HealthSystem.TakeDamage(damage);
    }

    public static void DestroyEntity(Entity e)
    {
        if (e is Victim) { 
            Victim.TOTAL_VICTIMS--;
            Debug.Log(Victim.TOTAL_VICTIMS);

            if(Victim.TOTAL_VICTIMS == 0)
            {
                EventManager.ExecuteEvent(Constants.ON_PLAYER_CLEARED_FLOOR);
            }
        }
        Destroy(e.gameObject);
    }
}
