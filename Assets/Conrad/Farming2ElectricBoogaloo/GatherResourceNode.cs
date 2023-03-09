using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceNodeType
{ 
    Undefined,
    Tree,
    Ore
}
[CreateAssetMenu(menuName ="Data/ToolAction/Gather Resource Node")]
public class GatherResourceNode : ToolAction
{
    [SerializeField] float sizeOfInteractableArea;
    [SerializeField] List<ResourceNodeType> canHitNodesOfType;
    public override bool OnApply(Vector2 worldPoint)
    {
        //Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //pos = playerCharacter.transform.position + delta.normalized;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                if (hit.CanBeHit(canHitNodesOfType) == true)
                {
                    hit.Hit();
                    return true;
                }
                
            }
        }

        return false;
    }
}
