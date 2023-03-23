using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using System;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay= 86400f;
    const float phaseLength = 900f; // 15 minutes chunck of time

    [SerializeField] Color nightLightColour;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColour = Color.white;


    float time;

    [SerializeField] float timescale = 60f;
    [SerializeField] float startAtTime = 28800f; //in seconds

    [SerializeField] TMP_Text text;
    [SerializeField] Light2D globalLight;

    private int days;

    List<TimeAgent> agents;
    private void Awake()
    {
        //globalLight = GameObject.Find("Light 2D").GetComponent<Light2D>();
        agents = new List<TimeAgent>();
    }

    private void Start()
    {
        time = startAtTime;
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }

    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
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
        if (globalLight == null)
        {
            globalLight = GameObject.Find("Light 2D").GetComponent<Light2D>();
        }

        time += Time.deltaTime * timescale;
        TimeValueCalculation();
        DayLight();

        if (time > secondsInDay)
        {
            NextDay();
        }

        TimeAgents();
    }

    

    

    private void TimeValueCalculation()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");
    }
    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColour, nightLightColour, v);
        globalLight.color = c;
    }

    int OldPhase = 0;

    private void TimeAgents()
    {
        int CurrentPhase = (int)(time / phaseLength);

        if (OldPhase != CurrentPhase)
        {
            OldPhase = CurrentPhase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }

        
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
