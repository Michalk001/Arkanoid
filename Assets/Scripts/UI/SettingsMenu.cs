using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
   
    private readonly float muteValue = -80f;
    public Slider slider;

    void Start()
    {
        if(GameSettingsManager.Instance != null)
        {
            SetSliderVolumeValue(GameSettingsManager.Instance.gameSettings.Volume);
        }
    }

    public void SetSliderVolumeValue(float value)
    {
        slider.value = value;
    }   

    public void SetVolume(float volume) {

        if (volume <= -29)
        {
            GameSettingsManager.Instance.audioMixer.SetFloat("volume", muteValue);
            GameSettingsManager.Instance.gameSettings.Volume = muteValue;
        }
        else
        {
            GameSettingsManager.Instance.audioMixer.SetFloat("volume", volume);
            GameSettingsManager.Instance.gameSettings.Volume = volume;
        }
       
    }
}
