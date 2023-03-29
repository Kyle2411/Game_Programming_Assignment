using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndHover : MonoBehaviour
{

    public float verticalSpeed;
    public float height;
    public float rotationSpeed;
    public Vector3 originalPos;
    public Vector3 tempPosition;


    void Start()
    {
        originalPos = transform.position;
        tempPosition = originalPos;
    }

    void FixedUpdate()
    {
        tempPosition = originalPos;
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * height;
        transform.position = tempPosition;
        
       transform.Rotate(new Vector3(0,0,10)*rotationSpeed*Time.deltaTime);
    
    }
}

