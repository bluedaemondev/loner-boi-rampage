using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{
    public static Entity Player;

    public Health HealthSystem;
    [SerializeField]
    private float health = 100;

    [SerializeField] protected HealthBar health_bar;
    [SerializeField] protected Animator m_animator;
    [SerializeField] protected IMovement default_movement;

    Coroutine sleepCo;



    protected virtual void Awake()
    {
        this.HealthSystem = new Health(health);
        this.health_bar.SetUpLifeBar(this.HealthSystem);
    }

    protected IEnumerator Sleep(float t)
    {
        Time.timeScale = 0.85f;
        yield return new WaitForSecondsRealtime(t);
        Time.timeScale = 1;

        sleepCo = null;
    }

    public static void DestroyEntity(Entity e)
    {
        GameManager.TOTAL_VICTIMS--;

        //Debug.Log(GameManager.TOTAL_VICTIMS);

        if (GameManager.TOTAL_VICTIMS == 0)
        {
            EventManager.ExecuteEvent(Constants.ON_PLAYER_CLEARED_FLOOR);
        }

        //}
        Destroy(e.gameObject);
    }

    protected void ToggleAnimatorBool(string toChange)
    {
        if (m_animator != null)
            m_animator.SetBool(toChange, !m_animator.GetBool(toChange));
    }
    protected void ToggleAnimatorTrigger(string triggName)
    {
        if (m_animator == null)
            return;

        m_animator.SetTrigger(triggName);
    }

    protected virtual void PlayDamagedAnimation()
    {
        ToggleAnimatorTrigger("damaged");
    }
    protected virtual void PlayDeadAnimation()
    {
        ToggleAnimatorTrigger("died");
    }

    public virtual void OnTakeDamage(float damage)
    {
        this.HealthSystem.TakeDamage(damage);
        SoundManager.instance.PlayAmbient("damaged_entity");

        if (sleepCo == null)
            sleepCo = StartCoroutine(Sleep(0.125f));
    }

    public virtual void OnExplode()
    {
        throw new System.NotImplementedException();
    }
}
