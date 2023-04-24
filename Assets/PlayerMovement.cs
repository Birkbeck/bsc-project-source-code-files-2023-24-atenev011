using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float rotationSpeed = 700f;

    private CharacterController controller;
    private Animator animator;
    private Camera mainCamera;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = CameraFollow.MainCamera;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool isWalking = Input.GetKey(KeyCode.W);
        bool isBackWalking = Input.GetKey(KeyCode.S);
        bool isLeftWalking = Input.GetKey(KeyCode.A);
        bool isRightWalking = Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && isWalking;

        float movementSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 cameraForward = mainCamera.transform.TransformDirection(Vector3.forward);
        cameraForward.y = 0;
        cameraForward = cameraForward.normalized;
        Vector3 cameraRight = new Vector3(cameraForward.z, 0, -cameraForward.x);

        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        controller.SimpleMove(moveDirection * movementSpeed);

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRightWalking", isRightWalking);
        animator.SetBool("isLeftWalking", isLeftWalking);
        animator.SetBool("isBackWalking", isBackWalking);
    }
}
