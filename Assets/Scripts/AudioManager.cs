using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private const string themeVolumePref = "ThemeMusicVolume";
    private const string soundEffectPref = "SoundEffectVolume";
    public string themeMusicName; 
    public Slider themeMusicSlider;
    public Slider soundEffectSlider;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            if(s.name == themeMusicName){
                float vol = PlayerPrefs.GetFloat(themeVolumePref, s.volume);
                s.SetVolume(vol);
            }
            else{
                float vol = PlayerPrefs.GetFloat(soundEffectPref, s.volume);
                s.SetVolume(vol);
            }
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        float themeVol = PlayerPrefs.GetFloat(themeVolumePref, 1);
        themeMusicSlider.value = themeVol;
        float soundVol = PlayerPrefs.GetFloat(soundEffectPref, 1);
        soundEffectSlider.value = soundVol;
    }
    void Start()
    {
        Play(themeMusicName);
    }

    void safePlay(Sound s)
    {
        if(s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogError("Sound "+s.name+" not found!");
        }
    }
    public Sound FindSound(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        safePlay(s);
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
        if(s != null)
        {
            s.source.Stop();
        }
    }
    public void SetVolume(string name, float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.SetVolume(vol);
    }
    
    public void SetThemeVolume(float vol)
    {
        SetVolume(themeMusicName, vol);
        PlayerPrefs.SetFloat(themeVolumePref, vol);
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
        PlayerPrefs.SetFloat(soundEffectPref, vol);
    }
}
