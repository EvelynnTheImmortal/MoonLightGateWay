using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarScroll : MonoBehaviour
{
    public GameObject[] uiElements;
    private int currentElementIndex = 0;

    void Update()
    {
        // Check if the user has scrolled up or down
        float scrollDelta = Input.mouseScrollDelta.y;
        if (scrollDelta > 0)
        {
            // Increase the current element index
            currentElementIndex = (currentElementIndex + 1) % uiElements.Length;
        }
        else if (scrollDelta < 0)
        {
            // Decrease the current element index
            currentElementIndex = (currentElementIndex + uiElements.Length - 1) % uiElements.Length;
        }

        // Loop through all UI elements
        for (int i = 0; i < uiElements.Length; i++)
        {
            // Check if current index matches current UI element
            if (i == currentElementIndex)
            {
                // Enable the UI element
                uiElements[i].SetActive(true);
            }
            else
            {
                // Disable the UI element
                uiElements[i].SetActive(false);
            }
        }
    }
}