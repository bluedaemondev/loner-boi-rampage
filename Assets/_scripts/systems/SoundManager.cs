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

    [Header("0: music | 1: ambient | 2: sound effects | 3: extras"), SerializeField]
    private AudioSource[] sources;

    void Awake()
    {
        if (instance == null)
            instance = this;

        if (sources == null)
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
    public void PlayMusic(string clip)
    {
        var cached = SoundLibrary.GetByName(clip, GameManager.Instance.GameSounds);

        if (cached != default(AudioClip))
        {
            this.sources[1].clip = cached;

            if (this.sources[1].isPlaying)
            {// aca falta una coroutine
                this.sources[1].PlayDelayed(0.2f);
            }
            else
                this.sources[1].Play();
        }
    }
    public void PlayAmbient(string clip)
    {
        var cached = SoundLibrary.GetByName(clip, GameManager.Instance.GameSounds);

        if (cached != default(AudioClip))
        {
            if (this.sources[1].isPlaying)
            {// aca falta una coroutine
                this.sources[1].clip = cached;
                this.sources[1].PlayDelayed(this.sources[2].clip.length);
            }
            else
                this.sources[1].PlayOneShot(cached);
        }
    }
    public void PlayExtraAmbient(string clip)
    {
        var cached = SoundLibrary.GetByName(clip, GameManager.Instance.GameSounds);

        if (cached != default(AudioClip))
        {
            if (this.sources[3].isPlaying)
            {// aca falta una coroutine
                this.sources[3].clip = cached;
                this.sources[3].PlayDelayed(this.sources[3].clip.length);
            }
            else
                this.sources[3].PlayOneShot(cached);
        }
    }
    public void PlayEffect(AudioClip clip)
    {
        this.sources[2].PlayOneShot(clip);
    }
    public void PlayEffect(string clipName)
    {
        var cached = SoundLibrary.GetByName(clipName, GameManager.Instance.GameSounds);

        if (cached != default(AudioClip))
        {
            if (this.sources[2].isPlaying)
            {// aca falta una coroutine
                this.sources[2].clip = cached;
                this.sources[2].PlayDelayed(this.sources[2].clip.length);
            }
            else
                this.sources[2].PlayOneShot(cached);
        }
    }
    public AudioClip GetEffect(string clipName)
    {
        var cached = SoundLibrary.GetByName(clipName, GameManager.Instance.GameSounds);

        if (cached != default(AudioClip))
            return cached;
        else return null;
    }
}
