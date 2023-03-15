using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public Transform tp1, tp2;
    public bool firstTeleporter;

    private void Awake()
    {
        player = GameObject.Find("Knight-Player");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
            player = GameObject.Find("Knight-Player");
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        if (firstTeleporter)
        {
            player.transform.position = tp2.transform.position;
        }
        else if (firstTeleporter == false)
        {
            player.transform.position = tp1.transform.position;
        }
    }
}
