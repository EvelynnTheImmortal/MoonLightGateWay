using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDisabler : MonoBehaviour
{
    public string tagToCheck; // The tag to check for
    public GameObject otherGameObject; // The game object with the collider to turn off

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider that entered the trigger has the tag we're looking for
        if (collision.gameObject.CompareTag(tagToCheck))
        {
            // Turn off the collider on the other game object
            otherGameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
