using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWeaponSwap : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    private int currentWeapon = 0;

    void Start()
    {
        // Activate the first weapon by default
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
    }

    void Update()
    {
        // Check if the player has scrolled the mouse wheel up or down
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            // Move to the next weapon
            currentWeapon = (currentWeapon + 1) % 3;
        }
        else if (scroll < 0f)
        {
            // Move to the previous weapon
            currentWeapon--;
            if (currentWeapon < 0)
            {
                currentWeapon = 2;
            }
        }

        // Activate the current weapon and deactivate the others
        switch (currentWeapon)
        {
            case 0:
                weapon1.SetActive(true);
                weapon2.SetActive(false);
                weapon3.SetActive(false);
                break;
            case 1:
                weapon1.SetActive(false);
                weapon2.SetActive(true);
                weapon3.SetActive(false);
                break;
            case 2:
                weapon1.SetActive(false);
                weapon2.SetActive(false);
                weapon3.SetActive(true);
                break;
        }
    }
}
