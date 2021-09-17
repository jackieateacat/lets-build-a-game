using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    private Transform thisTransform;

    [Range(0.1f, 5.0f)]
    public float scale = 1.0f;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }


    void Update()
    {
        Transform newScale = thisTransform;

        newScale.localScale = new Vector3 (scale, scale, scale);

        thisTransform = newScale;
    }
}
