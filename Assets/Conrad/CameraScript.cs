using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;

    public GameObject mainCam;
    public float rotationSpeed = 25.0f;
    public GameObject Top;
    public GameObject Bottom;
    public GameObject Left;
    public GameObject Right;
    public GameObject TopLeft;
    public GameObject TopRight;
    public GameObject BottomLeft;
    public GameObject BottomRight;
    public GameObject PlayerPOS;

    private Quaternion targetRotation = Quaternion.identity;
    private int MaxNum = 4;
    private int MinNum = -4;

    
    [SerializeField] private float duration = 1.0f;  // Time it takes to complete the movement
    [SerializeField] private Transform target;  // Target location for the movement

    private Vector3 startingPosition;  // Starting position of the object
    private float startTime;  // Time at which the movement starts
    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Awake()
    {
        if (!player)
        {
           
            player = GameObject.FindWithTag("Player").transform;
            
        }

        if (Top == null)
        {
            Top = GameObject.FindWithTag("TOP");
        }
        if (Bottom == null)
        {
            Bottom = GameObject.FindWithTag("BOTTOM");
        }
        if (Left == null)
        {
            Left = GameObject.FindWithTag("LEFT");
        }
        if (Right == null)
        {
            Right = GameObject.FindWithTag("RIGHT");
        }
        if (TopLeft == null)
        {
            TopLeft = GameObject.FindWithTag("TOP LEFT");
        }
        if (TopRight == null)
        {
            TopRight = GameObject.FindWithTag("TOP RIGHT");
        }
        if (BottomLeft == null)
        {
            BottomLeft = GameObject.FindWithTag("BOTTOM LEFT");
        }
        if (BottomRight == null)
        {
            BottomRight = GameObject.FindWithTag("BOTTOM RIGHT");
        }
        if (PlayerPOS == null)
        {
            PlayerPOS = GameObject.FindWithTag("PlayerPOS");
        }
    }
    void Update()
    {
        if (Top == null)
        {
            Top = GameObject.FindWithTag("TOP");
        }
        if (Bottom == null)
        {
            Bottom = GameObject.FindWithTag("BOTTOM");
        }
        if (Left == null)
        {
            Left = GameObject.FindWithTag("LEFT");
        }
        if (Right == null)
        {
            Right = GameObject.FindWithTag("RIGHT");
        }
        if (TopLeft == null)
        {
            TopLeft = GameObject.FindWithTag("TOP LEFT");
        }
        if (TopRight == null)
        {
            TopRight = GameObject.FindWithTag("TOP RIGHT");
        }
        if (BottomLeft == null)
        {
            BottomLeft = GameObject.FindWithTag("BOTTOM LEFT");
        }
        if (BottomRight == null)
        {
            BottomRight = GameObject.FindWithTag("BOTTOM RIGHT");
        }
        if (PlayerPOS == null)
        {
            PlayerPOS = GameObject.FindWithTag("PlayerPOS");
        }

        if (mainCam.transform.position.z >= 6)
        {

            Vector3 newPosition = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, 6);
            mainCam.transform.position = newPosition;
        }

        else if (mainCam.transform.position.z <= -6)
        {
            Vector3 newPosition = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, -6);
            mainCam.transform.position = newPosition;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(-10, 10, 0));
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, TopRight.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(-10, -10, 0));
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, TopLeft.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(10, 10, 0));
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, BottomRight.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(10, -10, 0));
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, BottomLeft.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(0, 10, 0));
           
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, Right.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            startingPosition = transform.position; 
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(0, -10, 0));
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, Left.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(-10, 0, 0));
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, Top.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            targetRotation = Quaternion.Euler(new Vector3(10, 0, 0));
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, Bottom.transform.position, elapsed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, PlayerPOS.transform.position, elapsed);
            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, PlayerPOS.transform.position, elapsed);
            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, PlayerPOS.transform.position, elapsed);
            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            startingPosition = transform.position; 
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, PlayerPOS.transform.position, elapsed);
            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            startingPosition = transform.position;  
            startTime = Time.time;
            float elapsed = (Time.time - startTime) / duration;
            elapsed = Mathf.Clamp01(elapsed);
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, PlayerPOS.transform.position, elapsed);
            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (transform.rotation != targetRotation)
        {
            
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }
    }
}
