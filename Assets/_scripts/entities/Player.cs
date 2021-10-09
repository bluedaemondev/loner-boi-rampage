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


    protected override void Awake()
    {
        Player = this;
        base.Awake();
        this.default_movement = new StickMovement(this.m_rigidbody, movementInput, speed);

        this.HealthSystem.SubscribeDamagedHandler(PlayDamagedAnimation);
        this.HealthSystem.SubscribeDeadHandler(PlayDeadAnimation);

        ((StickMovement)this.default_movement).SubscribeOnMoveHandler(MoveAnimationHandler);

    }

    private void Start()
    {
        var tmp = System.Enum.GetName(typeof(PickupType), defaultGun);
        EventManager.ExecuteEvent(Constants.ON_WEAPON_CHANGE, tmp);
    }

    private void FixedUpdate()
    {
        default_movement.Move();
    }

    private void MoveAnimationHandler(float magnitudeOfMovement)
    {
        Debug.Log(string.Format("mag {0}", magnitudeOfMovement));
        if (magnitudeOfMovement > 0)
        {
            m_animator.SetBool("iswalking", true);
        }
        else
        {
            m_animator.SetBool("iswalking", false);
        }
    }


}
