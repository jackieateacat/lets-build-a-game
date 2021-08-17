using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIDefaultButtonScript : MonoBehaviour
{
    [Tooltip("Animator reference")]
    [SerializeField]
    Animator animator;

    [Tooltip("Flag to know if button is already animating")]
    bool isBusy;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void OnClick()
    {
        if (!isBusy)
        {
            isBusy = true;
            animator.SetTrigger("Click");
        }
    }

    public void FinishClick()
    {
        isBusy = false;
        animator.ResetTrigger("Click");
    }
}
