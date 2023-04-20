using System.Net;
using System.Reflection;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Player walks
        if (Input.GetKey("w") && !Input.GetKey("q"))
        {
            animator.SetBool("param_idletowalk", true);
            animator.SetBool("param_idletorun", false); // stop running
        }
        else
        {
            animator.SetBool("param_idletowalk", false);
        }

        // Player runs
        if (Input.GetKey("q") && !Input.GetKey("w"))
        {
            animator.SetBool("param_idletorun", true);
            animator.SetBool("param_idletowalk", false); // stop walking
        }
        else if (!Input.GetKey("w")) // if not walking
        {
            animator.SetBool("param_idletorun", false);
        }
    }
}
