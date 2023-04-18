using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterInteractController : MonoBehaviour
{
    CharacterController playCharacter;
    Rigidbody2D rgbd2d;
    Vector3 pos;
    public GameObject playerCharacter;
    AttackTrigger aT;
    Character character;

    [SerializeReference] HighlightController highlightController;

    [SerializeField] float offsetDistance = 1;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        
        //playCharacter = GetComponent<CharacterController>();

        //rgbd2d = GetComponent<Rigidbody2D>();

        //aT = GetComponent<AttackTrigger>();

        character = GetComponent<Character>();
    }

   

    private void Update()
    {
        Check();

        //Ts = playerCharacter.transform.position;
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Check()
    {
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        pos = playerCharacter.transform.position + delta.normalized;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, sizeOfInteractableArea);

       

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject);
                return;
            }
        }

        
         highlightController.Hide();
        
    }

    private void Interact()
    {
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        pos = playerCharacter.transform.position + delta.normalized;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }


    }
}
