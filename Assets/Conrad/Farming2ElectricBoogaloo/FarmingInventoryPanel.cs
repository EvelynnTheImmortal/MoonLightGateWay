using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingInventoryPanel : FarmingItemPanel
{
    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id]);
        Show();
    }
}
