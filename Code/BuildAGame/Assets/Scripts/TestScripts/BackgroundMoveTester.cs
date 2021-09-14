using UnityEngine;

public class BackgroundMoveTester : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        cameraTransform.position += new Vector3(-0.1f, 0);
    }
}