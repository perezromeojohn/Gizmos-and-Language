using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Settings : MonoBehaviour
{

    public Slider musicSlider;
    // get our mixer
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume")) {
            // set to .7
            PlayerPrefs.SetFloat("MusicVolume", 1);
            load();
        } else {
            load();
        }
    }

    public void onChangeSlider() {
        // set the volume of the mixer to the value of the slider
        audioMixer.SetFloat("MusicVolume", musicSlider.value);
        save();
    }

    // use playerprefs to save the volume
    public void load() {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void save() {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
