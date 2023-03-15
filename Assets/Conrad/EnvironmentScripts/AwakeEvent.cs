using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeEvent : MonoBehaviour
{
    public GameObject Player;
    public GameObject thisObject;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = thisObject.transform.position;
    }
}
