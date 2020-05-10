using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    public void Start()
    {
        //if(slider.value != 0)
        //{
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("GameVolume"));
            slider.value = PlayerPrefs.GetFloat("SliderValue");
        //}
        //else
        //{
        //    slider.value = 0;
        //    audioMixer.SetFloat("GameVolume", 0);
        //    PlayerPrefs.SetFloat("SliderValue", slider.value);
        //}

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.SetFloat("SliderValue", slider.value);
    }
}
