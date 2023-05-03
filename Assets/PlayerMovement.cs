/// <summary>
/// Author: atenev01
/// Class for player movement.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f; // Walking speed
    public float runSpeed = 5f; // Running speed
    public float rotationSpeed = 700f; // Rotation speed

    private CharacterController controller; // Reference to character controller
    private Animator animator; // Reference to animator component
    private Camera mainCamera; // Reference to main camera

    private void Start()
    {
        controller = GetComponent<CharacterController>(); // Get character controller component
        animator = GetComponent<Animator>(); // Get animator component
        mainCamera = CameraFollow.MainCamera; // Get reference to main camera
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input
        float vertical = Input.GetAxis("Vertical"); // Get vertical input

        bool isWalking = Input.GetKey(KeyCode.W); // Check if walking forward
        bool isBackWalking = Input.GetKey(KeyCode.S); // Check if walking backward
        bool isLeftWalking = Input.GetKey(KeyCode.A); // Check if walking left
        bool isRightWalking = Input.GetKey(KeyCode.D); // Check if walking right
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W); // Check if running

        float movementSpeed = isRunning ? runSpeed : walkSpeed; // Set movement speed based on whether running

        Vector3 cameraForward = mainCamera.transform.TransformDirection(Vector3.forward); // Get forward vector of camera
        cameraForward.y = 0; // Set y-component to 0
        cameraForward = cameraForward.normalized; // Normalize vector
        Vector3 cameraRight = new Vector3(cameraForward.z, 0, -cameraForward.x); // Calculate right vector based on forward vector

        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized; // Calculate movement direction

        if (moveDirection != Vector3.zero && isWalking) // If moving and walking forward
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up); // Calculate new rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); // Rotate character
        }

        controller.SimpleMove(moveDirection * movementSpeed); // Move character

        animator.SetBool("isRunning", isRunning); // Set running animation
        animator.SetBool("isWalking", isWalking); // Set walking animation
        animator.SetBool("isRightWalking", isRightWalking); // Set right walking animation
        animator.SetBool("isLeftWalking", isLeftWalking); // Set left walking animation
        animator.SetBool("isBackWalking", isBackWalking && !isRunning); // Set backward walking animation
    }
}
