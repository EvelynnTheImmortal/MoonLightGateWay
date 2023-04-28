using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLootEnabler : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;

    private void Update()
    {
        if (objectToDestroy != null)
        {
            // Object to destroy has been destroyed, activate the other two objects
            objectToActivate1.SetActive(true);
            objectToActivate2.SetActive(true);
        }
    }
}
