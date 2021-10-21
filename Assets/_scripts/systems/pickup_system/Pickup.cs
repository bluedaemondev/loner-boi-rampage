using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Collider m_collider;
    [SerializeField] private Animator m_animator;

    [SerializeField] private List<PickupWTransform> assetPrefabs;

    private IPickup pickupStrategy;

    // Start is called before the first frame update
    void Reset()
    {
        // to do: 
        // reset animator
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pickup on pickup! PIKA PIKA PIKA");
        this.pickupStrategy.SetGrabber(other.gameObject);
        this.pickupStrategy.OnGrabPickup();
        DropFactory.Instance.pool.ReturnObject(this);

    }

    public Pickup SetPickupStrategy(IPickup newStrat, PickupType type)
    {
        this.pickupStrategy = newStrat;
        bool comp = false;

        for (int i = 0; i < this.assetPrefabs.Count; i++)
        {
            comp = i == (int)type; //test
            assetPrefabs[i].transform.gameObject.SetActive(comp);
        }

        return this;
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
