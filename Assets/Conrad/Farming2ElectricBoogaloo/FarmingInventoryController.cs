using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingInventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            panel.SetActive(!panel.activeInHierarchy);
        }
    }
}
