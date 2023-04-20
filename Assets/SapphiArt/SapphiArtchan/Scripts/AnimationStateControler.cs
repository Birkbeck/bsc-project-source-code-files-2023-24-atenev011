using System.Net;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateControler : MonoBehaviour
{
    Animator animator;
    int isRightWalkingHash;
    int isLeftWalkingHash;
    int isWalkingHash;
    int isRunningHash;
    int isBackWalkingHash; // new variable to store the hash for "isBackWalkingHash"
    
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isRightWalkingHash = Animator.StringToHash("isRightWalking");
        isLeftWalkingHash = Animator.StringToHash("isLeftWalking");
        isBackWalkingHash = Animator.StringToHash("isBackWalking"); // initialize the new variable
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isLeftWalking = animator.GetBool(isLeftWalkingHash);
        bool isRightWalking = animator.GetBool(isRightWalkingHash);
        bool isBackWalking = animator.GetBool(isBackWalkingHash); // get the value of "isBackWalkingHash"
        bool forwardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey("s"); // new variable to store whether "s" is pressed
        bool runPressed = Input.GetKey("left shift");
        bool rightPressed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("a");
        
        if (!isWalking && forwardPressed)
        {        
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {        
            animator.SetBool(isWalkingHash, false);
        }
        
        if (!isWalking && rightPressed)
        {
            animator.SetBool(isRightWalkingHash, true);
        }
        else
        {
            animator.SetBool(isRightWalkingHash, false);
        }
        
        if (!isWalking && leftPressed)
        {
            animator.SetBool(isLeftWalkingHash, true);
        }
        else
        {
            animator.SetBool(isLeftWalkingHash, false);
        }
        
        // check if the "s" key is pressed while the player is not already walking backwards
        if (!isWalking && backPressed && !isBackWalking)
        {
            animator.SetBool(isBackWalkingHash, true); // set "isBackWalking" to true
        }
        else
        {
            animator.SetBool(isBackWalkingHash, false); // set "isBackWalking" to false
        }
        
        if (forwardPressed && runPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        else
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
