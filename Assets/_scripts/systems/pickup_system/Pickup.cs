using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Collider m_collider;
    [SerializeField] private Animator m_animator;
    //[SerializeField] LayerMask interactionLayers;

    [SerializeField] private IPickup pickupStrategy;

    // Start is called before the first frame update
    void Reset()
    {
        //pickupStrategy = new HealthPickup()
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public static void TurnOn(Pickup b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Pickup b)
    {
        b.gameObject.SetActive(false);
    }


}
