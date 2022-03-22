using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using TMPro; 
 
using UnityEngine.Rendering; 
 
public class DayNightCycle : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay; 
    public TextMeshProUGUI dayDisplay; 
    public Volume ppv; 
 
    public float tick; 
    public float seconds; 
    public int mins;
    public int hours;
    public int days = 1;
 
    public bool activateLights; 
    public GameObject[] lights; 
    public SpriteRenderer[] stars;
    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }
 
    // Update is called once per frame
    void FixedUpdate() 
    {
        CalcTime();
        DisplayTime();

    }
 
    public void CalcTime() 
    {
        seconds += Time.fixedDeltaTime * tick;
 
        if (seconds >= 60) 
        {
            seconds = 0;
            mins += 1;
        }
 
        if (mins >= 60) 
        {
            mins = 0;
            hours += 1;
        }
 
        if (hours >= 24)
        {
            hours = 0;
            days += 1;
        }
    
        if (hours>=6 && hours<15)
        {
            ppv.weight = 1 - (float)mins / 60; 
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, 1 -(float)mins / 60); 
            }
            if (activateLights == true) 
            {
                if (mins > 45) 
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); 
                    }
                    activateLights = false;
                }
            }
        }
    }
 
    public void DisplayTime()
    {
 
        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins); 
        dayDisplay.text = "Day: " + days; 
    }
}