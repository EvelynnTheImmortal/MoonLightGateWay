using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lootContainerInteract : Interactable
{
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openChest;
    [SerializeField] bool opened;


    public override void Interact(Character character)
    {
        if (opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openChest.SetActive(true);
        }
    }
}
