using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMusic (float volume)
    {
        //audioMixer.SetFloat("music", volume);
    }

    public void SetSound(float volume)
    {
        //audioMixer.SetFloat("sound", volume);
    }
}
