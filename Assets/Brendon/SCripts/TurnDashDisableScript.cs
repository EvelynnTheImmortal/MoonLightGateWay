using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDashDisableScript : MonoBehaviour
{
    public MonoBehaviour scriptToEnable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            scriptToEnable.enabled = true;
        }
    }
}
