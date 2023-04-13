using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab of the arrow sprite
    public float spawnInterval = 1f; // Time interval between spawns
    public float spawnForce = 10f; // Force applied to the spawned arrow
    public Transform spawnPoint; // Point where the arrow is spawned

    private void Start()
    {
        // Call SpawnArrow method repeatedly at the specified spawn interval
        InvokeRepeating("SpawnArrow", spawnInterval, spawnInterval);
    }

    private void SpawnArrow()
    {
        // Instantiate the arrow prefab at the spawn point
        GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);

        // Apply force to the arrow in the direction of the spawn point's forward vector
        arrow.GetComponent<Rigidbody2D>().AddForce(spawnPoint.right * spawnForce, ForceMode2D.Impulse);
    }
}
