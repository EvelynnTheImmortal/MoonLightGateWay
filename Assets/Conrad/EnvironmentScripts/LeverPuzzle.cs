using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    public GameObject lever;
    private LeverSwitcher ls;
    private SpriteRenderer sP;
    public GameObject switchCavas;
    public bool isInSquare = false;
    public Sprite animState1;
    public Sprite animState2;
    public GameObject secretDoor;
    public bool lever1;
    public bool lever2;
    private  bool lever1Triggered;
    private  bool lever2Triggered;

    public GameObject leverobj1;
    public GameObject leverobj2;
    public LeverPuzzle lv1;
    public LeverPuzzle lv2;
    private void Awake()
    {
        ls = lever.GetComponent<LeverSwitcher>();
        sP = lever.GetComponent<SpriteRenderer>();
        //lv1 = leverobj1.GetComponent<LeverPuzzle>();
        //lv2 = leverobj2.GetComponent<LeverPuzzle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switchCavas.SetActive(true);
            isInSquare = true;
        }
           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switchCavas.SetActive(false);
            isInSquare = false;
        }
        
    }

    private void Update()
    {
        if (lv1.lever1Triggered == true)
        {
            lever1Triggered = true;
        }
        if (lv2.lever2Triggered == true)
        {
            lever2Triggered = true;
        }

        if (isInSquare == true && Input.GetKeyDown(KeyCode.E))
        {
            if (lever1)
            {
                TriggerSecretDoor();
                lever1Triggered = true;
            }
            if(lever2)
            {
                TriggerSecretDoor();
                lever2Triggered = true;
            }
            
            
        }

        if (lever1Triggered && lever2Triggered)
        {
            secretDoor.SetActive(false);
        }
    }
    private void TriggerSecretDoor()
    {
        
        StartCoroutine(SwitchAnim());
        //StartCoroutine(CanvasActivation());
    }
    IEnumerator SwitchAnim()
    {
        sP.sprite = animState1;
        yield return new WaitForSeconds(0.1f);
        sP.sprite = animState2;
        StopCoroutine(SwitchAnim());
    }
}
