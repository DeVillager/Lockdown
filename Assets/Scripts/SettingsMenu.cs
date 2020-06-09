using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;


    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSoundsVolume(float volume)
    {
        soundMixer.SetFloat("SoundVolume", Mathf.Log10(volume) * 20);
    }

}
