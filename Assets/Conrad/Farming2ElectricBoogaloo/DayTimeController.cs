using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using System;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay= 86400f;

    [SerializeField] Color nightLightColour;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColour = Color.white;


    float time;

    [SerializeField] float timescale = 60f;

    [SerializeField] TMP_Text text;
    [SerializeField] Light2D globalLight;

    private int days;
    private void Awake()
    {
        globalLight = GameObject.Find("Light 2D").GetComponent<Light2D>();
        
    }

   
    
    float Hours
    {
        get { return time / 3600f; }
    }

    float Minutes
    {
        get { return time % 3600f / 60f;  }
    }

    private void Update()
    {
        time += Time.deltaTime * timescale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColour, nightLightColour, v);
        globalLight.color = c;
        if (time > secondsInDay)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
