using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Collider m_collider;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Transform assetContainer;
    //[SerializeField] LayerMask interactionLayers;

    [SerializeField] private IPickup pickupStrategy;

    // Start is called before the first frame update
    void Reset()
    {
        // to do: 
        // reset animator
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pickup on pickup! PIKA PIKA PIKA");

        this.pickupStrategy.OnGrabPickup();
        DropFactory.Instance.pool.ReturnObject(this);
    }

    public Pickup SetPickupStrategy(IPickup newStrat)
    {
        this.pickupStrategy = newStrat;
        return this;
    }

    public static void TurnOn(Pickup b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Pickup b)
    {
        Destroy(b.assetContainer.GetChild(0).gameObject);

        b.gameObject.SetActive(false);
    }


}
