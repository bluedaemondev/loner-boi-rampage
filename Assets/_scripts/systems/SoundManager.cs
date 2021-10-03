using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Manager de sonido general. Maneja 3 canales por mixer, que estan cargados como componentes de
/// este mismo GameObject
/// </summary>
public class SoundManager : MonoBehaviour
{
    // Juan Lanosa
    public static SoundManager instance { get; private set; }
    
    [Header("0: music | 1: ambient | 2: sound effects"), SerializeField]
    private AudioSource[] sources;

    void Awake()
    {
        if (instance == null)
            instance = this;

        if(sources == null)
        {
            Debug.LogError("Missing audio sources!!");
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        this.sources[0].clip = clip;
        if (!this.sources[0].isPlaying)
            this.sources[0].Play();
    }
    public void PlayAmbient(AudioClip clip)
    {
        this.sources[1].PlayOneShot(clip);
    }
    public void PlayEffect(AudioClip clip)
    {
        this.sources[2].PlayOneShot(clip);
    }
}
