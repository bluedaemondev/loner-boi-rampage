using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAddon : MonoBehaviour, IGunner
{
    [SerializeField] private Transform aimTarget;
    private Coroutine fireLoopCoroutine;

    //private float gunShotInterval;
    private YieldInstruction gunShotWaiter;

    private Action onShootEvent;

    [SerializeField]
    private Gun gunInHand;

    // Start is called before the first frame update
    protected void Awake()
    {
        gunShotWaiter = new WaitForSeconds(gunInHand.TimeBetweenShots);
        StartFire();
    }

    protected virtual void FixedUpdate()
    {
        transform.LookAt(aimTarget/*transform.position + simulatedInputVec*/);

    }
    public void SubscribeToOnShoot(Action method)
    {
        this.onShootEvent += method;
    }

    public IEnumerator FireLoop()
    {
        while (true)
        {
            yield return gunShotWaiter;
            onShootEvent?.Invoke();
        }
    }

    public virtual void HaltFire()
    {
        if (fireLoopCoroutine != null)
        {
            StopCoroutine(fireLoopCoroutine);
            fireLoopCoroutine = null;
        }
    }

    public void StartFire()
    {
        if (fireLoopCoroutine == null)
        {
            fireLoopCoroutine = StartCoroutine(FireLoop());
        }
    }

    
}
