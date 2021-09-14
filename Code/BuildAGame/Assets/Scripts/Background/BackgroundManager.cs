using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [Tooltip("Place here a reference to the background GameObject that should stay fixed in relation to the Camera.")]
    [SerializeField] private GameObject staticBackground;

    [Tooltip("Place here a reference to each scrolling background GameObject you wish to use in this Scene.")]
    [SerializeField] private ParallaxBackground[] parallaxBackgrounds;

    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;

        if (staticBackground != null)
        {
            staticBackground.transform.parent = cameraTransform;
        }

        foreach (var background in parallaxBackgrounds)
        {
            background.startPosition = background.instance.transform.position;
            background.spriteWidth = background.instance.GetComponent<SpriteRenderer>().bounds.size.x;
            CreateClones(background);
        }
    }

    private void LateUpdate()
    {
        foreach (var background in parallaxBackgrounds)
        {
            float parallaxMovement = cameraTransform.position.x * background.parallaxMultiplier;
            float distanceToStart = cameraTransform.position.x * (1 - background.parallaxMultiplier);

            background.instance.transform.position = new Vector3(background.startPosition.x + parallaxMovement,
                                                                 background.instance.transform.position.y);

            if (distanceToStart > background.startPosition.x + background.spriteWidth)
            {
                background.startPosition.x += background.spriteWidth;
            }
            else if (distanceToStart < background.startPosition.x - background.spriteWidth)
            {
                background.startPosition.x -= background.spriteWidth;
            }
        }
    }

    private void CreateClones(ParallaxBackground background)
    {
        var leftClone = Instantiate(background.instance,
                                    new Vector3(background.instance.transform.position.x - background.spriteWidth,
                                                background.instance.transform.position.y),
                                    Quaternion.identity);

        var rightClone = Instantiate(background.instance,
                                     new Vector3(background.instance.transform.position.x + background.spriteWidth,
                                                 background.instance.transform.position.y),
                                     Quaternion.identity,
                                     background.instance.transform);

        leftClone.transform.parent = background.instance.transform;

        leftClone.transform.localScale = new Vector3(1, 1, 1);
        rightClone.transform.localScale = new Vector3(1, 1, 1);
    }
}