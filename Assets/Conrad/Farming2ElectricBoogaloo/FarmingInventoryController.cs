using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingInventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            panel.SetActive(!panel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }

    public void SeedBagUIButton()
    {
        panel.SetActive(!panel.activeInHierarchy);
        toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
    }
}
