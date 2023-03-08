using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class ToolsCharacterControler : MonoBehaviour
{
    CharacterController character;
    AttackTrigger aT;
    Vector3 pos;
    public GameObject playerCharacter;
    Rigidbody2D rgbd2d;
    Vector2 Ts;
    [SerializeField] float offsetDistance = 1;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    
    [SerializeField] float maxDistance = 1.5f;

    [SerializeField] CropsManager cropsManager;

    [SerializeField] TileData plowableTiles;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<CharacterController>();

        rgbd2d = GetComponent<Rigidbody2D>();

        aT = GetComponent<AttackTrigger>();

        markerManager = GameObject.Find("Grid").GetComponentInChildren<MarkerManager>();
        tileMapReadController = GameObject.Find("TileMapInterface").GetComponent<TileMapReadController>();
        cropsManager = GameObject.Find("TileMapInterface").GetComponent<CropsManager>();


    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        
        if (Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }
    private void Marker()
    {
      
       markerManager.markedCellPosition = selectedTilePosition;
    }

    private bool UseToolWorld()
    {
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        pos = playerCharacter.transform.position + delta.normalized;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                return true;
            }
        }
        return false;
    }

    private void UseToolGrid()
    {
        if (selectable == true)
        {
            TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = tileMapReadController.GetTileData(tileBase);
            if (tileData != plowableTiles)
            {
                return;
            }
            if (cropsManager.Check(selectedTilePosition))
            {
                cropsManager.Seed(selectedTilePosition);
            }
            else
            {
                cropsManager.Plow(selectedTilePosition);
            }
            
        }
    }
}
