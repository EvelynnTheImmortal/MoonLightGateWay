using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AreanaGameMode : MonoBehaviour
{
    public GameObject MonsterSpawners;
    public Tilemap tilemap1;
    public Tilemap tilemap2;
    public List<TileBase> requiredTiles; // The specific Tile to search for on first tile map
    public List<TileBase> replacementTiles; // The specific Tile to search for on second tile map

    public Sprite specificSprite; // The specific sprite to check for
    private bool spriteSpawned = false;
    private bool triggeredOnce = true;
    private bool allTilesChanged;
    private Coroutine lastCoroutine;
    public GameObject highlightTilemap;

    public GameObject door1;
    public GameObject door2;

    private List<GameObject> spawnersInScene;
    private List<GameObject> tileMapsInScene;
    private Vector3 WorldSpawn;
    public GameObject GridRef;


    private void Start()
    {
        allTilesChanged = false;
        spriteSpawned = false;
        triggeredOnce = true;
    }

    private void Update()
    {
        if (!allTilesChanged)
        {
            bool allRequiredTilesChanged = true;
            bool allReplacementTilesChanged = true;

            // Check for required tiles in tilemap1
            foreach (Vector3Int pos in tilemap1.cellBounds.allPositionsWithin)
            {
                TileBase tile = tilemap1.GetTile(pos);
                if (requiredTiles.Contains(tile))
                {
                    if (!replacementTiles.Contains(tilemap2.GetTile(pos)))
                    {
                        allRequiredTilesChanged = false;
                        break;
                    }
                }
            }

            // Check for replacement tiles in tilemap2
            foreach (Vector3Int pos in tilemap2.cellBounds.allPositionsWithin)
            {
                TileBase tile = tilemap2.GetTile(pos);
                if (replacementTiles.Contains(tile))
                {
                    if (!requiredTiles.Contains(tilemap1.GetTile(pos)))
                    {
                        allReplacementTilesChanged = false;
                        break;
                    }
                }
            }

            if (allRequiredTilesChanged && allReplacementTilesChanged && triggeredOnce)
            {
                lastCoroutine = StartCoroutine(TileMapSpawner());
                allTilesChanged = true;
                MonsterSpawners.SetActive(true);
                triggeredOnce = false;
                door1.SetActive(true);
            }

        }

        SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>();
        bool spriteExists = false;
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if (spriteRenderer.sprite == specificSprite)
            {
                spriteSpawned = true;
                spriteExists = true;
                door1.SetActive(false);
                MonsterSpawners.SetActive(false);
                // Trigger action when specific sprite exists
                // TODO: Add your desired action here
                break;
            }
        }

        if (!spriteExists && spriteSpawned)
        {
            tileMapsInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("TileMarker"));
            if (tileMapsInScene != null)
            {
                foreach (GameObject TMIS in tileMapsInScene)
                {
                    Destroy(TMIS);
                }
            }
            //door1.SetActive(false);
            door2.SetActive(false);
        }
    }

    IEnumerator TileMapSpawner()
    {
        spawnersInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("GMSR"));
        if (spawnersInScene != null)
        {
            foreach (GameObject GMSR in spawnersInScene)
            {
                Destroy(GMSR);
            }
        }

        tileMapsInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("TileMarker"));
        if (tileMapsInScene != null)
        {
            foreach (GameObject TMIS in tileMapsInScene)
            {
                Destroy(TMIS);
            }
        }

        yield return new WaitForSeconds(29f);

        WorldSpawn = new Vector3(0, 0, -1.5f);
        var myTileObject = Instantiate(highlightTilemap, WorldSpawn, Quaternion.identity);

        myTileObject.transform.parent = GridRef.transform;
        myTileObject.transform.position = WorldSpawn;

        StopCoroutine(lastCoroutine);


    }
}

