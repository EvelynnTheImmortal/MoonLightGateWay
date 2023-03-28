using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BpShopSceneSwitcher : MonoBehaviour
{
    public string BpShopInterier; // The name of the scene to load
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("BpShopInterier");
        }
    }
}
