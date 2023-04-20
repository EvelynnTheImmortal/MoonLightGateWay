using System;
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
    public Animator animator;
    FarmingToolBarController toolBarController;
    public GameObject playerCharacter;
    Rigidbody2D rgbd2d;
    Vector2 Ts;
    [SerializeField] float offsetDistance = 1;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] ToolAction onTilePickUp;
    
    [SerializeField] float maxDistance = 1.5f;

    

    //[SerializeField] TileData plowableTiles;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        //character = GetComponent<CharacterController>();

        //rgbd2d = GetComponent<Rigidbody2D>();

        //aT = GetComponent<AttackTrigger>();

        //markerManager = GameObject.Find("Grid").GetComponentInChildren<MarkerManager>();
        //tileMapReadController = GameObject.Find("TileMapInterface").GetComponent<TileMapReadController>();
        
        toolBarController = GetComponent<FarmingToolBarController>();
        //animator = GameObject.Find("Knight-Player").GetComponentInChildren<Animator>();


    }

    private void Update()
    {
        if (markerManager == null)
        {
            markerManager = GameObject.Find("Grid").GetComponentInChildren<MarkerManager>();
        }
        if (tileMapReadController == null)
        {
            tileMapReadController = GameObject.Find("TileMapInterface").GetComponent<TileMapReadController>();
        }

        SelectTile();
        CanSelectCheck();
        Marker();
        
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
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
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, sizeOfInteractableArea);

        Item item = toolBarController.GetItem;
        if (item == null)
        {
            return false;
        }
        if (item.onAction == null)
        {
            return false;
        }

        animator.SetTrigger("Act");
        bool complete = item.onAction.OnApply(pos);

        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }


        }
        return complete;
    }

    private void UseToolGrid()
    {
        if (selectable == true)
        {
            Item item = toolBarController.GetItem;
            if (item == null)
            {
                PickUpTile();
                return;
            }
            if (item.onTileMapAction == null)
            {
                
                return;
            }
            animator.SetTrigger("Act");
            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController, item);
            //Debug.Log("THY");
            if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
                

            }
        }
    }

    private void PickUpTile()
    {
        if (onTilePickUp == null)
        {
            return;
        }

        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
    }
}
