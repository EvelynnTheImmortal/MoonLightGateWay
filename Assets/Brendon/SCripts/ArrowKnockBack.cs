using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKnockBack : MonoBehaviour
{
    public float knockbackForce = 10f; // Force applied to the player when hit by the arrow

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the arrow hits a player
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Hit registered");
            //// Get the player's transform and arrow's transform
            //Transform playerTransform = collision.gameObject.transform;
            //Transform arrowTransform = transform;

            //// Calculate the direction from the arrow to the player
            //Vector2 direction = (Vector2)arrowTransform.right; // Arrow is moving parallel to hallway, so knockback direction is arrow's right
            //Debug.Log("Direction of arrow is noted");

            // Apply knockback force to the player in the knockback direction
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = Vector2.zero; // Reset player's velocity to avoid interference
            playerRigidbody.AddForce(Vector3.forward * -5);
            Debug.Log("Player is knocked back");
        }
    }
}
