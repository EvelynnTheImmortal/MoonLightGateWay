using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileCheckerForEvironment6 : MonoBehaviour
{
    public Tilemap tilemap1;
    public Tilemap tilemap2;
    public List<TileBase> requiredTiles;
    public List<TileBase> replacementTiles;
    public GameObject objectToTrigger;
    public GameObject SecretDoor2;
    public GameObject highlightTilemap;

    private bool allTilesChanged;

    private void Start()
    {
        allTilesChanged = false;
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

            if (allRequiredTilesChanged && allReplacementTilesChanged)
            {
                Debug.Log("All required tiles have been changed.");
                allTilesChanged = true;
                objectToTrigger.SetActive(false);
                SecretDoor2.SetActive(false);
                Destroy(highlightTilemap);
                
            }
        }
    }
}


