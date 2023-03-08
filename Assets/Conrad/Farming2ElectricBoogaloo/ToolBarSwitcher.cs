using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarSwitcher : MonoBehaviour
{
    public GameObject FightingUI;
    public GameObject FarmingUI;
    public GameObject PlayerUI;

    int num = 0;

    private void Awake()
    {
        num = 0;
        FightingUI.SetActive(true);
        FarmingUI.SetActive(false);
    }

    private void Update()
    {
        UICycle();

        
    }

    private void UICycle()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            num++;

            if (num > 2)
            {
                num = 0;
            }

            if (num == 0)
            {
                PlayerUI.SetActive(true);
                FightingUI.SetActive(true);
                FarmingUI.SetActive(false);

            }
            else if (num == 1)
            {
                PlayerUI.SetActive(true);
                FightingUI.SetActive(false);
                FarmingUI.SetActive(true);

            }
            else if (num == 2)
            {
                PlayerUI.SetActive(false);
            }
        }
    }
}
