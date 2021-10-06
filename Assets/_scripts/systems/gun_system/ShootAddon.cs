using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAddon : MonoBehaviour, IGunner
{
    [SerializeField] private AnalogStickInput stick;
    private Vector3 simulatedInputVec;
    private Coroutine fireLoopCoroutine;

    private float gunShotInterval;
    private YieldInstruction gunShotWaiter;

    private Action onShootEvent;

    // Start is called before the first frame update
    protected void Awake()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    protected virtual void FixedUpdate()
    {
        transform.LookAt(transform.position + simulatedInputVec);
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
        throw new NotImplementedException();
    }

    public void SetGunshotInterval(float time)
    {
        throw new NotImplementedException();
    }

    public void StartFire()
    {
        throw new NotImplementedException();
    }

    
}
