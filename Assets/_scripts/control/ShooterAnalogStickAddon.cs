using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAnalogStickAddon : MonoBehaviour, IGunner
{
    [SerializeField] private AnalogStickInput stick;
    private Vector3 simulatedInputVec;
    private Coroutine fireLoopCoroutine;

    private float gunShotInterval;
    private YieldInstruction gunShotWaiter;

    private Action onShootEvent;

    public void SubscribeToOnShoot(Action method)
    {
        this.onShootEvent += method;
    }

    ///// <summary>
    ///// Llamada externa para cargar la cadencia del arma que tengo en la mano
    ///// </summary>
    ///// <param name="time"></param>
    //public void SetGunshotInterval(float time)
    //{
    //    this.gunShotInterval = time;
    //    this.gunShotWaiter = new WaitForSeconds(time);
    //}

    public void StartFire()
    {
        if (fireLoopCoroutine == null)
        {
            fireLoopCoroutine = StartCoroutine(FireLoop());
        }
    }

    public void HaltFire()
    {
        if (fireLoopCoroutine != null)
        {
            StopCoroutine(fireLoopCoroutine);
            fireLoopCoroutine = null;
        }
    }

    public IEnumerator FireLoop()
    {
        while (true)
        {
            yield return gunShotWaiter;
            onShootEvent?.Invoke();
        }
    }

    /// sacar esta inicializacion. que salga del arma
    private void Awake()
    {
        gunShotWaiter = new WaitForSeconds(gunShotInterval);

        stick.SubscribeToOnPress(StartFire);
        stick.SubscribeToOnRelease(HaltFire);

        

    }

    private void Update()
    {
        simulatedInputVec.x = stick.Value.x;
        simulatedInputVec.z = stick.Value.y;

        Debug.Log(simulatedInputVec.magnitude);
    }
    private void FixedUpdate()
    {
        transform.LookAt(transform.position + simulatedInputVec);
    }
}
