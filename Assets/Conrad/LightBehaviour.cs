
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.InteropServices.WindowsRuntime;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBehaviour : MonoBehaviour
{
    public GameObject playerLight;
    public Light2D pL;
    private float targetIntensity;
    private float duration;
    private float initialIntensity;
    Coroutine InRoutine = null;
    Coroutine OutRoutine = null;
    private bool triggerEnter = false;
    private bool triggerExit = false;
    private float targetSize;
    private float initialSize;


    private void Awake()
    {
        playerLight.SetActive(true);
        pL.intensity = 1f;
        InRoutine = null;
        OutRoutine = null;
        triggerEnter = false;
        triggerExit = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plight")
        {
            triggerExit = false;
            triggerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plight")
        {
            triggerEnter = false;
            triggerExit = true;
        }
    }

    private void Update()
    {

        if (triggerEnter == true && triggerExit == false)
        {
            if (InRoutine != null)
            {
                StopCoroutine(InRoutine);
            }
            OutRoutine = StartCoroutine(outfade());
        }
        if (triggerExit == true && triggerEnter == false)
        {
            if (OutRoutine != null)
            {
                StopCoroutine(OutRoutine);
            }

            InRoutine = StartCoroutine(infade());
        }
    }

    IEnumerator infade()
    {

        targetIntensity = 1f;
        initialIntensity = pL.intensity;
        duration = targetIntensity + initialIntensity * 60;

        targetSize = 2f;
        initialSize = pL.pointLightOuterRadius;


        float startTime = Time.time;
        float endTime = startTime + duration;
        // Loop until the end time is reached
        while (Time.time < endTime)
        {
            // Calculate the current time ratio (0 to 1)
            float timeRatio = (Time.time - startTime) / duration;

            // Lerp the intensity from the initial intensity to the target intensity
            float newIntensity = Mathf.Lerp(initialIntensity, targetIntensity, timeRatio);
            float newOutSize = Mathf.Lerp(initialSize, targetSize, timeRatio);
            // Set the new intensity to the light
            pL.intensity = newIntensity;
            pL.pointLightOuterRadius = newOutSize;
            
            if (initialIntensity == targetIntensity)
            {
                pL.intensity = targetIntensity;
                pL.pointLightOuterRadius = targetSize;
                break;
            }
            // Wait for the next frame
            yield return null;

        }

        pL.intensity = targetIntensity;
        pL.pointLightOuterRadius = targetSize;

    }

    IEnumerator outfade()
    {
        
        targetIntensity = 0f;
        initialIntensity = pL.intensity;
        duration = targetIntensity + initialIntensity * 60;

        targetSize = 0f;
        initialSize = pL.pointLightOuterRadius;

        float startTime = Time.time;
        float endTime = startTime + duration;
        // Loop until the end time is reached
        while (Time.time < endTime)
        {
            // Calculate the current time ratio (0 to 1)
            float timeRatio = (Time.time - startTime) / duration;

            // Lerp the intensity from the initial intensity to the target intensity
            float newIntensity = Mathf.Lerp(initialIntensity, targetIntensity, timeRatio);
            float newOutSize = Mathf.Lerp(initialSize, targetSize, timeRatio);

            // Set the new intensity to the light
            pL.intensity = newIntensity;
            pL.pointLightOuterRadius = newOutSize;

            if (initialIntensity == targetIntensity)
            {
                pL.intensity = targetIntensity;
                pL.pointLightOuterRadius = targetSize;
                break;
            }

            // Wait for the next frame
            yield return null;
        }
        pL.intensity = targetIntensity;
        pL.pointLightOuterRadius = targetSize;
    }
}


