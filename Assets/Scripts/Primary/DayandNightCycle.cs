using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; // used to access the volume component
using TMPro; // using text mesh for the clock display

public class DayandNightCycle : MonoBehaviour
{
    public Volume ppv; // this is the post processing volume
 
    public float tick = 500; // Increasing the tick, increases second rate
    public float seconds; 
    public int mins;
    public int hours;
    public int days = 1;
 
    public bool activateLights; // checks if lights are on
    bool lightsOffDuringDawn = false; // checks if lights are off during dawn
    public GameObject[] lights; // all the lights we want on when its dark
    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();

        // if hour is greater than 19 and less than 6, turn the lights on
        if(hours>=19 || hours<6) {
            for (int i = 0; i < lights.Length; i++)
            {
                if(lights[i] != null) {
                    lights[i].SetActive(true);
                }
            }
            activateLights = true;
        }
    }
 
    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
        // DisplayTime();
        if(hours>=6 && hours<7 && !lightsOffDuringDawn) {
            for (int i = 0; i < lights.Length; i++)
            {
                if(lights[i] != null) {
                    lights[i].SetActive(false);
                }
            }
            lightsOffDuringDawn = true;
        }
     
    }

    void OnEnable()
    {
        tick = PlayerPrefs.GetFloat("tick", tick);
        seconds = PlayerPrefs.GetFloat("seconds", seconds);
        mins = PlayerPrefs.GetInt("mins", mins);
        hours = PlayerPrefs.GetInt("hours", hours);
        days = PlayerPrefs.GetInt("days", days);
        ppv.weight = PlayerPrefs.GetFloat("ppvWeight", ppv.weight);

        activateLights = false;
        for (int i = 0; i < lights.Length; i++)
        {
            if(lights[i] != null) {
                string key = "light" + i;
                int value = PlayerPrefs.GetInt(key, lights[i].activeSelf ? 1 : 0);
                lights[i].SetActive(value == 1);
            }
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("tick", tick);
        PlayerPrefs.SetFloat("seconds", seconds);
        PlayerPrefs.SetInt("mins", mins);
        PlayerPrefs.SetInt("hours", hours);
        PlayerPrefs.SetInt("days", days);
        PlayerPrefs.SetFloat("ppvWeight", ppv.weight);

        for (int i = 0; i < lights.Length; i++)
        {
            if(lights[i] != null) {
                string key = "light" + i;
                int value = lights[i].activeSelf ? 1 : 0;
                PlayerPrefs.SetInt(key, value);
            }
        }

        PlayerPrefs.Save();
    }
 
    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick
 
        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            mins += 1;
        }
 
        if (mins >= 60) //60 min = 1 hr
        {
            mins = 0;
            hours += 1;
        }
 
        if (hours >= 24) //24 hr = 1 day
        {
            hours = 0;
            days += 1;
        }
        ControlPPV(); // changes post processing volume after calculation
    }
 
    public void ControlPPV() // used to adjust the post processing slider.
    {
        //ppv.weight = 0;
        if(hours>=19 && hours<20) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            ppv.weight =  (float)mins / 60; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1 
            if (activateLights == false) // if lights havent been turned on
            {
                if (mins > 45) // wait until pretty dark
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // turn them all on
                    }
                    activateLights = true;
                }
            }
        }
     
 
        if(hours>=6 && hours<7) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            ppv.weight = 1 - (float)mins / 60; // we minus 1 because we want it to go from 1 - 0
            if (activateLights == true) // if lights are on
            {
                if (mins > 25) // wait until pretty bright
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // shut them off
                    }
                    activateLights = false;
                }
            }
        }
    }
 
    // public void DisplayTime() // Shows time and day in ui
    // {
 
    //     timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins); // The formatting ensures that there will always be 0's in empty spaces
    //     dayDisplay.text = "Day: " + days; // display day counter
    // }
}
