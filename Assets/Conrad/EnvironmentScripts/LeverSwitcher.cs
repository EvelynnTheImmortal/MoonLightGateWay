using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeverSwitcher : MonoBehaviour
{
    public TMP_Text Mstext;
    public GameObject globalCanvas;
    public GameObject lever;
    private LeverSwitcher ls; 
    public GameObject secretDoor;
    public GameObject switchCavas;
    public bool isInSquare = false;
    private SpriteRenderer sP;
    public Sprite animState1;
    public Sprite animState2;

    private bool istriggered = false;
    private void Awake()
    {
        ls = lever.GetComponent<LeverSwitcher>();
        sP = lever.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lever != null && istriggered == false)
        {
            switchCavas.SetActive(true);
            isInSquare = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (lever != null && istriggered == false)
        {
            switchCavas.SetActive(false);
            isInSquare = false;
        }
        
    }

    private void Update()
    {
        if (isInSquare == true && Input.GetKeyDown(KeyCode.E) && istriggered == false)
        {
            TriggerSecretDoor();
            istriggered = true;
        }
    }

    private void TriggerSecretDoor()
    {
        secretDoor.SetActive(true);
        lever = null;
        StartCoroutine(SwitchAnim());
        StartCoroutine(CanvasActivation());
    }
    IEnumerator SwitchAnim()
    {
        sP.sprite = animState1;
        yield return new WaitForSeconds(0.1f);
        sP.sprite = animState2;
        StopCoroutine(SwitchAnim());
    }

    IEnumerator CanvasActivation()
    {
        globalCanvas.SetActive(true);
        Mstext.text = "The sound of metal shifting is heard...";
        yield return new WaitForSeconds(2f);
        Mstext.text = "";
        globalCanvas.SetActive(false);
        StopCoroutine(CanvasActivation());
    }
}
