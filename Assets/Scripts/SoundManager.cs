using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    // Singleton instance.
    public static SoundManager Instance = null;

    public AudioClip[] soundClips;
    public AudioClip[] musicClips;


    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
        PlayLockDown();
    }

    //private void Awake()
    //{
    //    PlayLockDown();
    //}

    // Play a single clip through the sound effects source.
    public void Play(string name)
    {
        foreach (AudioClip clip in soundClips)
        {
            if (clip.name == name)
            {
                EffectsSource.clip = clip;
                EffectsSource.Play();
            }
        }
    }

    public void PlayMusic(string name)
    {
        foreach (AudioClip clip in musicClips)
        {
            if (clip.name == name)
            {
                MusicSource.Stop();
                MusicSource.clip = clip;
                MusicSource.Play();
            }
        }
    }

    // Play a single clip through the music source.


    public void PlayClick()
    {
        Play("blip");
    }

    public void PlayRecovery()
    {
        Play("recover");
    }

    public void PlayCancel()
    {
        Play("back");
    }

    public void PlayUse()
    {
        Play("use");
    }

    public void PlayPCOn()
    {
        Play("pcOn");
    }

    public void PlayWork()
    {
        Play("work");
    }

    public void PlayStudy()
    {
        Play("work");
    }

    public void PlayVictory()
    {
        PlayMusic("victory");
    }

    public void PlayLockDown()
    {
        PlayMusic("lockdown");
    }
}