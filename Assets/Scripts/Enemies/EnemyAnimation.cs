using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on GameObject.");
        }
    }

    public void SetRunningState(bool isRunning)
    {
        if (animator != null)
        {
            animator.SetBool("isRunning", isRunning);
        }
        else
        {
            Debug.LogError("Animator component is not initialized.");
        }
    }

    public void ToggleKickedState()
    {
        if (animator != null)
        {
            bool isKicked = animator.GetBool("isKicked");
            animator.SetBool("isKicked", !isKicked);
        }
        else
        {
            Debug.LogError("Animator component is not initialized.");
        }
    }
}
