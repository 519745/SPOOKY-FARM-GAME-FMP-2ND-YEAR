using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{
    TimeManager tm;
    Text display;
    public bool _24HourClock = true;
    DayNightCycle TMExtra;



    // Start is called before the first frame update
    void Start()
    {
        //tm = FindObjectOfType<TimeManager>();
        TMExtra = FindObjectOfType<DayNightCycle>();
        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = Mathf.FloorToInt(TMExtra.hours).ToString("00") + ":" + Mathf.FloorToInt(TMExtra.mins).ToString("00");

        
    }
}