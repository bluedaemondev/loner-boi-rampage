using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private AnalogStickInput movementInput;
    [Header("Elegir solo armas")]
    [SerializeField] private PickupType defaultGun;

    protected override void Awake()
    {
        base.Awake();

        this.default_movement = new StickMovement(this.m_rigidbody);
    }

    private void Start()
    {
        var tmp = System.Enum.GetName(typeof(PickupType), defaultGun);
        Debug.Log("tmp = " + tmp);
        EventManager.ExecuteEvent(Constants.ON_WEAPON_CHANGE, tmp);
    }

    private void FixedUpdate()
    {
        default_movement.Move(movementInput.Value);
    }


}
