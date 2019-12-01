using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private float muteValue = -80f;

    public void SetVolume(float volume) { 
    
        if (volume <= -29)
            audioMixer.SetFloat("volume", muteValue);
        else
            audioMixer.SetFloat("volume", volume);
    }
}
