using UnityEngine;

[System.Serializable]
public class ParallaxBackground
{
    [Tooltip("This should be a reference to the background GameObject present in the scene.")]
    public GameObject instance;

    [Tooltip("A value of 1.0f means the background stays fixed. The lower the value, the faster the background is going to move in relation to the Camera.")]
    public float parallaxMultiplier = 1.0f;

    [HideInInspector]
    public Vector3 startPosition;

    [HideInInspector]
    public float spriteWidth;
}