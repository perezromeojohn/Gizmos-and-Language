using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsData : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume")) {
            // set to .7
            PlayerPrefs.SetFloat("MusicVolume", 0);
            // get the value of the playerprefs, set it to the mixer
            audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        } else {
            // get the value of the playerprefs, set it to the mixer
            audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }
    }
}
