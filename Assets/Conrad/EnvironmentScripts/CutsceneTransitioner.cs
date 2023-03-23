using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTransitioner : MonoBehaviour
{
    //private int DialogueAmount = 0;
    //public int AmountOfDialgueEvents = 0;
    //public int AmountTillCameraDestruction = 0;

    public GameObject playerSpawner;
    public Transform spawnLocation;
    private GameObject MainSceneCamera;
    //public GameObject textBox;

    private bool isReset = true;
    //public CutsceneTransitioner cT;

    //private void Start()
    //{
    //    MainSceneCamera = GameObject.FindGameObjectWithTag("MainCamera");
    //    //cT = this;
    //}

    private void Awake()
    {
        MainSceneCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Instantiate(playerSpawner, spawnLocation.transform.position, Quaternion.identity);
        MainSceneCamera.SetActive(false);
    }

    

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && isReset)
    //    {
    //        isReset = false;
    //        DialogueAmount++;
    //        StartCoroutine(RestClick());

    //    }
    //    if (DialogueAmount == AmountOfDialgueEvents)
    //    {
    //        Instantiate(playerSpawner, spawnLocation.transform.position, Quaternion.identity);
            
    //    }
    //    if (DialogueAmount == AmountTillCameraDestruction)
    //    {
    //        textBox.SetActive(false);
    //        MainSceneCamera.SetActive(false);
    //        Destroy(this.gameObject);
    //    }
    //}

    //IEnumerator RestClick()
    //{
    //    yield return new WaitForSeconds(2f);
    //    isReset = true;
    //    StopCoroutine(RestClick());
    //}
}
