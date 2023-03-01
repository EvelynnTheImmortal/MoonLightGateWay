using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingUIToggle : MonoBehaviour
{
    public GameObject FarmingUI;
    public GameObject CombatUI;
    private bool isInFarminglevel = false;
    

    private int UISwitcherNum = 1;

    private void Awake()
    {
        
        if (GameObject.Find("FarmingUICanvas") != null)
        {
            FarmingUI = GameObject.Find("FarmingUICanvas");
            isInFarminglevel = true;
            UISwitcherNum = 2;
        }
        else
        {
            isInFarminglevel = false;
            UISwitcherNum = 1;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isInFarminglevel)
        {
            UISwitcherNum++;

            if (UISwitcherNum > 2)
            {
                UISwitcherNum = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !isInFarminglevel)
        {
            UISwitcherNum++;
            if (UISwitcherNum > 1)
            {
                UISwitcherNum = 0;
            }
        }

        
        
        if (UISwitcherNum == 0)
        {
            CombatUI.SetActive(false);
            FarmingUI.SetActive(false);
        }
        else if (UISwitcherNum == 1)
        {
            CombatUI.SetActive(true);
            FarmingUI.SetActive(false);
        }

        else if (UISwitcherNum == 2)
        {
            CombatUI.SetActive(true);
            FarmingUI.SetActive(true);
        }
    }
}
