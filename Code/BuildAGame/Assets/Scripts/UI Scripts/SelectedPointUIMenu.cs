using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SelectedPointUIMenu : MonoBehaviour
{
    [Tooltip("Reference to the object animator")]
    [SerializeField]
    Animator animator;

    [Tooltip("Reference to the title text")]
    [SerializeField]
    TMP_Text title;

    [Tooltip("Reference to the description text")]
    [SerializeField]
    TMP_Text description;

    [Tooltip("Reference to the description text")]
    [SerializeField]
    float animationDuration;

    [Tooltip("Flag to detect if menu is already open")]
    bool isOpen;

    Vector2 initialSize;

    private void Awake()
    {
        initialSize = transform.localScale;
        transform.localScale = Vector2.zero;
    }

    /// <summary>
    /// OpenPointMenu is responsible for opening the point menu with the point menu information
    /// </summary>
    /// <param name="mapPoint">The map point with all the information to be loaded</param>
    public void OpenPointMenu(MapPointScriptable mapPoint)
    {
        transform.localScale = initialSize;
        title.text = mapPoint.mapPointName;
        description.text = mapPoint.mapPointDescription;
    }

    /// <summary>
    /// ClosePointMenu is responsible for closing the menu
    /// </summary>
    public void ClosePointMenu()
    {
        transform.localScale = Vector2.zero;
    }

    //Animation will be handled by code?...
    public void ClosePointMenu(MapPointScriptable mapPoint)
    {
        //StartCoroutine(AnimateMenu(animationDuration, Vector2.zero, transform));
    }

    public static IEnumerator AnimateMenu(float duration, Vector2 targetSize, Transform transform)
    {
        if (duration > 0)
        {
            float currentTime = 0;
            Vector2 currentSize = transform.localScale;
            while (currentTime < duration)                                                                          // while duration not over
            {
                currentTime += Time.deltaTime;                                                                      // increment duration
                transform.localScale = Vector2.Lerp(currentSize, targetSize, currentTime / duration);
                yield return null;                                                                                  // keep yield
            }
        }
        else
        {
            transform.localScale = targetSize;
        }
        yield break;
    }
}