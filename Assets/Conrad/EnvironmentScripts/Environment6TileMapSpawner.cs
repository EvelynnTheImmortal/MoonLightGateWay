using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Environment6TileMapSpawner : MonoBehaviour
{
    public GameObject tileMapMarker;
    
    public bool isSpawner;
    public bool isDestroyer;
    public bool isGMDestroyer;

    private Vector3 WorldSpawn;
    private List<GameObject> tileMapsInScene;
    private List<GameObject> spawnersInScene;
    public GameObject GridRef;

    private void Awake()
    {
        WorldSpawn = new Vector3(0, 0, -1.5f);
        tileMapsInScene = new List<GameObject>();
        spawnersInScene = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSpawner && collision.tag == "Player")
        {
            WorldSpawn = new Vector3(0, 0, -1.5f);
            var myTileObject = Instantiate(tileMapMarker, WorldSpawn, Quaternion.identity);

            myTileObject.transform.parent = GridRef.transform;
            myTileObject.transform.position = WorldSpawn;
        }
        else if (isDestroyer && collision.tag == "Player")
        {
            tileMapsInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("TileMarker"));

            if (tileMapsInScene != null)
            {
                foreach (GameObject TMIS in tileMapsInScene)
                {
                    Destroy(TMIS);
                }

            }
        }
        else if (isGMDestroyer && collision.tag == "Player")
        {
            tileMapsInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("TileMarker"));

            if (tileMapsInScene != null)
            {
                foreach (GameObject TMIS in tileMapsInScene)
                {
                    Destroy(TMIS);
                }

            }

            spawnersInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("GMSR"));

            if (spawnersInScene != null)
            {
                foreach (GameObject GMSR in spawnersInScene)
                {
                    Destroy(GMSR);
                }

            }
        }
    }


}
