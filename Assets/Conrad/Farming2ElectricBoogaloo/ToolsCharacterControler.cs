using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        character = GetComponent<CharacterController>();

        rgbd2d = GetComponent<Rigidbody2D>();

        aT = GetComponent<AttackTrigger>();

        
        
    }

    private void Update()
    {
        //Ts = playerCharacter.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
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
                break;
            }
        }


    }
}
