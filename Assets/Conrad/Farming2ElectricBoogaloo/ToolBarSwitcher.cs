using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ToolBarSwitcher : MonoBehaviour
{
    public GameObject FightingUI;
    public GameObject FarmingUI;
    public GameObject PlayerUI;

    public ToolsCharacterControler PTCC;
    public FarmingInventoryController PIC;
    public FarmingToolBarController PFTBC;
    public CharacterInteractController PFCIC;
    public GameObject PFHC;
    

    //public SideQuestStat PCSQS;
    //public QuestStat PCQS;
    public AttackTrigger PCAT;
    public Transform farmingPoint;

    //Vector3 pos;
    //public GameObject playerCharacter;
    //[SerializeField] float offsetDistance = 1;
    //[SerializeField] float sizeOfInteractableArea = 1.2f;

    int num = 0;

    private void Awake()
    {
        num = 0;
        FightingUI.SetActive(true);
        FarmingUI.SetActive(false);
        PCAT.enabled = true;

        PTCC.enabled = false;
        PIC.enabled = false;
        PFTBC.enabled = false;
        PFCIC.enabled = false;
        if (PFHC != null)
        {
            PFHC.SetActive(false);
        }



        farmingPoint.position = transform.position;
         farmingPoint.rotation = transform.rotation;
         
            
        
    }

    private void Update()
    {
        UICycle();
        
        if (num == 1 || num == 2)
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(farmingPoint.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            farmingPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            

            

            //Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //pos = playerCharacter.transform.position + delta.normalized;
            //Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, sizeOfInteractableArea);
        }
    }

    private void UICycle()
    {
        if (PFHC == null)
        {
            PFHC = GameObject.FindGameObjectWithTag("TileMarker");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            num++;

            if (num > 2)
            {
                num = 0;
            }

            if (num == 0)
            {
                PlayerUI.SetActive(true);
                FightingUI.SetActive(true);
                FarmingUI.SetActive(false);
                PCAT.enabled = true;

                PTCC.enabled = false;
                PIC.enabled = false;
                PFTBC.enabled = false;
                PFCIC.enabled = false;
                if (PFHC != null)
                {
                    PFHC.SetActive(false);
                }

            }
            else if (num == 1)
            {
                PlayerUI.SetActive(true);
                FightingUI.SetActive(false);
                FarmingUI.SetActive(true);
                PCAT.enabled = false;

                PTCC.enabled = true;
                PIC.enabled = true;
                PFTBC.enabled = true;
                PFCIC.enabled = true;
                if (PFHC != null)
                {
                    PFHC.SetActive(true);
                }

            }
            else if (num == 2)
            {
                PlayerUI.SetActive(false);
                PCAT.enabled = false;

                PTCC.enabled = false;
                PIC.enabled = false;
                PFTBC.enabled = false;
                PFCIC.enabled = false;
                if (PFHC != null)
                {
                    PFHC.SetActive(false);
                }
            }
        }
    }
}
