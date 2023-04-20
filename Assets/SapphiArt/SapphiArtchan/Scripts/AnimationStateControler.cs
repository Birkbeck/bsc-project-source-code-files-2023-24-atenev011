using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateControler : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash; // new variable to store the hash for "isRunning"
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning"); // initialize the new variable
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash); // get the value of "isRunning"
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        
        if (!isWalking && forwardPressed)
        {        
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {        
            animator.SetBool(isWalkingHash, false);
        }
        
        // check if both "w" and "left shift" keys are pressed simultaneously
        if (forwardPressed && runPressed)
        {
            animator.SetBool(isRunningHash, true); // set "isRunning" to true
        }
        else
        {
            animator.SetBool(isRunningHash, false); // set "isRunning" to false
        }
    }
}
