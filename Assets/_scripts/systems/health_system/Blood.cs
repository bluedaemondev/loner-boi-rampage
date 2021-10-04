using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;

    //private void OnParticleSystemStopped()
    //{
        
    //}

    private void Reset()
    {
        particles.Clear();
        particles.Play();
    }

    public static void TurnOn(Blood b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Blood b)
    {
        b.particles.Stop();
        b.gameObject.SetActive(false);
    }
}
