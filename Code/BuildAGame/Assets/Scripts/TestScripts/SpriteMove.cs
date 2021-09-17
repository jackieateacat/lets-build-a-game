using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour
{
    public Vector2 speed;
    public bool useCameraPosition = false;

    private Rigidbody2D rigidRef;
    private Transform cameraPosition;
    private Vector3 lastPosition;

    private void Start()
    {
        rigidRef = GetComponent<Rigidbody2D>();
        lastPosition = Camera.main.transform.position;
    }

    void Update()
    {
        if(!useCameraPosition)
        {
            rigidRef.velocity = speed;
        }
        else
        {
            transform.position += lastPosition - Camera.main.transform.position;
        }

 
    }
}
