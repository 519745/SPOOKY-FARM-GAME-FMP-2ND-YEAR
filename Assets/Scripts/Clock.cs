using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    TimeManager tm;

    public RectTransform skyDome;
    public float TimerSpeed = 1f;

    

    float nightHoursToDegrees, dayHoursToDegrees;

    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TimeManager>();

        nightHoursToDegrees = 180 / (TimeManager.hoursInDay * tm.nightDuration);
        dayHoursToDegrees = 180 / (TimeManager.hoursInDay * (1 - tm.nightDuration));

        //skyDome.rotation = Quaternion.Euler(0,0,0+tm.sunriseHour*nightHoursToDegrees);
    }

    // Update is called once per frame
    void Update()
    {
        if(((tm.GetHour()<tm.sunriseHour || tm.GetHour() > tm.GetSunsetHour())&&tm.sunriseHour<tm.GetSunsetHour()) ||
           ((tm.GetHour() < tm.sunriseHour && tm.GetHour() > tm.GetSunsetHour()) && tm.sunriseHour > tm.GetSunsetHour()))
        {
            skyDome.Rotate(0,0,-Time.deltaTime * TimerSpeed *TimeManager.hoursInDay * nightHoursToDegrees/tm.dayDuration);
        }
        else
        {
            skyDome.Rotate(0, 0, -Time.deltaTime * TimerSpeed * TimeManager.hoursInDay * dayHoursToDegrees / tm.dayDuration);
        }
    }
}