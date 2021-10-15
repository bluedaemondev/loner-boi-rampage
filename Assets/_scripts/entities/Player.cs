using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float speed = 5;
    [SerializeField] private AnalogStickInput movementInput;
    
    [Header("Elegir solo armas")]
    [SerializeField] private PickupType defaultGun;

    [SerializeField] private Rigidbody m_rigidbody;

    [SerializeField] private Gun selectedGun;


    protected override void Awake()
    {
        Player = this;
        base.Awake();

#if UNITY_ANDROID
        this.default_movement = new StickMovement(this.m_rigidbody, movementInput, speed);
        ((StickMovement)this.default_movement).SubscribeOnMoveHandler(MoveAnimationHandler);
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
        this.default_movement = new KeyboardMovement(this.m_rigidbody, speed);
        ((KeyboardMovement)this.default_movement).SubscribeOnMoveHandler(MoveAnimationHandler);

#endif
        this.HealthSystem.SubscribeDamagedHandler(PlayDamagedAnimation);
        this.HealthSystem.SubscribeDeadHandler(PlayDeadAnimation);

        this.selectedGun.shotHelper = this.GetComponent<ShooterAnalogStickAddon>();
        this.selectedGun.shotHelper.SubscribeToOnShoot(Shoot);

    }

    private void Start()
    {
        //var tmp = System.Enum.GetName(typeof(PickupType), defaultGun);
        EventManager.ExecuteEvent(Constants.ON_WEAPON_CHANGE, selectedGun.name);
    }

    private void FixedUpdate()
    {
        default_movement.Move();
    }

    private void MoveAnimationHandler(float magnitudeOfMovement)
    {
        //Debug.Log(string.Format("mag {0}", magnitudeOfMovement));
        if (magnitudeOfMovement > 0)
        {
            m_animator.SetBool("iswalking", true);
        }
        else
        {
            m_animator.SetBool("iswalking", false);
        }
    }
    private void Shoot()
    {
        m_animator.Play("shooting");
    }
    private void Damaged()
    {
        m_animator.SetTrigger("damaged");
    }
}
