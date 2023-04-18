using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCutscene : MonoBehaviour
{

    public GameObject Camera;

    private void Start()
    {
        
    }

    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(1f);
    }

}
