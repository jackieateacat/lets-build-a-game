using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class UIDefaultButtonScript : MonoBehaviour
{
    [Tooltip("Animator reference")]
    [SerializeField]
    Animator animator;

    [Tooltip("Audio source reference")]
    [SerializeField]
    AudioSource audioSource;

    [Tooltip("Point UI Menu reference")]
    [SerializeField]
    SelectedPointUIMenu pointUIMenu;

    [Tooltip("Point UI Menu reference")]
    [SerializeField]
    MapPointScriptable mapPointScriptable;

    [Tooltip("Flag to know if button is already animating")]
    bool isBusy;

    /// <summary>
    /// Awake function is reponsible for getting references if null
    /// </summary>
    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    /// <summary>
    /// OnClick function handles click, it triggers the animation and loads this point information in the menu
    /// </summary>
    public void OnClick()
    {
        if (!isBusy)
        {
            isBusy = true;
            mapPointScriptable.soundPlayEvent.Play(audioSource);
            animator.SetTrigger("Click");
            pointUIMenu.OpenPointMenu(mapPointScriptable);
        }
    }

    /// <summary>
    /// FinishedClick is responsible for setting the flag isBusy back to false on enf od animation
    /// </summary>
    public void FinishClick()
    {
        isBusy = false;
        animator.ResetTrigger("Click");
    }

    /// <summary>
    /// Sets the information of this map point
    /// </summary>
    public void SetMapPointScriptable(MapPointScriptable _mapPointScriptable)
    {
        mapPointScriptable = _mapPointScriptable;
    }

    /// <summary>
    /// Sets the reference of the point UI menu to show the point information
    /// </summary>
    public void SetPointUIMenu(SelectedPointUIMenu _pointUIMenu)
    {
        pointUIMenu = _pointUIMenu;
    }
}
