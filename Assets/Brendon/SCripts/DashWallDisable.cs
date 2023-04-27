using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashWallDisable : MonoBehaviour
{
    public GameObject objectToDisable;
    public int staminaThreshold = 33;

    public TopdownInputController2D tD;

    private bool isEPressed = false;
    private void Awake()
    {
        tD = GameObject.FindGameObjectWithTag("Player").GetComponent<TopdownInputController2D>();
    }

    private void Update()
    {
        //if (tD == null)
        //{
        //    tD = GameObject.FindGameObjectWithTag("Player").GetComponent<TopdownInputController2D>();
        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    isEPressed = true;
        //}

        if (Input.GetKey(KeyCode.Space) && tD.currentStamina > staminaThreshold) /*&& isEPressed && tD.canDash*/ /*&& Time.timeScale != 0.0f && !GlobalStatus.freezePlayer && !GlobalStatus.freezeAll*/
        {
            Debug.Log("this is working");
            //objectToDisable.GetComponent<BoxCollider2D>().enabled = false;
            objectToDisable.SetActive(false);
        }
        //if (Input.GetKey(KeyCode.Space) && GetComponent<TopdownInputController2D>().currentStamina < staminaThreshold)
        //{
        //    Debug.Log("this is working");
        //}

    }
}