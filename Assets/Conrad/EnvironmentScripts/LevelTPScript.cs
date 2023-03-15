using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTPScript : MonoBehaviour
{
    public int editorInt;
    

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelSelect();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
        }
    }

    private void LevelSelect()
    {
        if (editorInt == 0)
        {
            SceneManager.LoadScene("Camp");
        }
        else if (editorInt == 1)
        {
            SceneManager.LoadScene("CNEnvironment1");
        }
        else if (editorInt == 2)
        {

        }
    }
}
