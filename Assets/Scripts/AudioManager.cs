using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public string themeMusicName; 
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Play("Theme1");
    }

    void safePlay(Sound s, string name)
    {
        if(s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogError("Sound "+name+" not found!");
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        safePlay(s, name);
    }

    public void TurnOn(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(!s.source.isPlaying)
        {
            s.source.Play();
        }
    }
    public void TurnOff(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void SetVolume(string name, float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.SetVolume(vol);
    }
    
    public void SetThemeVolume(float vol)
    {
        SetVolume(themeMusicName, vol);
    }
    public void SetSoundEffectVolume(float vol)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == themeMusicName){
                continue;
            }
            s.SetVolume(vol);
        }
    }
}
