using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LevelMenuSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    public void Start()
    {
         audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("GameVolume"));
         slider.value = PlayerPrefs.GetFloat("SliderValue");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.SetFloat("SliderValue", slider.value);
    }
}
