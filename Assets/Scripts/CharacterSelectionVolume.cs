using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterSelectionVolume : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("GameVolume"));
    }

}
