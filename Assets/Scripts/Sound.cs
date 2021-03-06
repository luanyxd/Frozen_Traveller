﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
    public void SetVolume(float vol)
    {
        this.volume = vol;
        if(this.source)
            this.source.volume = vol;
        else
            Debug.Log("Can't find volume source in sound:"+this.name);
    }
}
