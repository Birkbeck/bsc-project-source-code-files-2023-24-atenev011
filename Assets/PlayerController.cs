using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float runMultiplier = 1.5f;
    public float rotationSpeed = 10.0f;
    public Transform cameraTransform;
    private Animator animator;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector3 moveDirection = (cameraTransform.forward * verticalInput + cameraTransform.right * horizontalInput).normalized;
        moveDirection.y = 0;

        if (verticalInput != 0 || horizontalInput != 0)
        {
            if (isRunning && verticalInput > 0) moveDirection *= runMultiplier * moveSpeed;
            else moveDirection *= moveSpeed;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        moveDirection.y -= 9.81f * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        animator.SetBool("isWalking", verticalInput != 0 || horizontalInput != 0);
        animator.SetBool("isRunning", isRunning && verticalInput > 0);
    }
}
