using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public bool isMainIsland = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isMainIsland)
        {
            SceneManager.LoadScene("HomeBase2");
        }
        else if (isMainIsland == false)
        {
            SceneManager.LoadScene("Camp");
        }
    }

    
}
