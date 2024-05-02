using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float moveSpeed = 3.0f;
    private float rotationSpeed = 100.0f;
    private float gravity = 9.81f;
    private bool isWalking;
    private bool isRunning;
    private bool isRightWalking;
    private bool isLeftWalking;
    private bool isBackWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        isWalking = false;
        isRunning = false;
        isRightWalking = false;
        isLeftWalking = false;
        isBackWalking = false;

        if (vertical > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 6.0f;
                isRunning = true;
            }
            else
            {
                moveSpeed = 3.0f;
                isWalking = true;
            }
            moveDirection = transform.forward * moveSpeed * vertical;
        }
        else if (vertical < 0)
        {
            moveSpeed = 3.0f;
            isBackWalking = true;
            moveDirection = transform.forward * moveSpeed * vertical;
        }
        else if (horizontal > 0)
        {
            moveSpeed = 3.0f;
            isRightWalking = true;
            moveDirection = transform.right * moveSpeed * horizontal;
        }
        else if (horizontal < 0)
        {
            moveSpeed = 3.0f;
            isLeftWalking = true;
            moveDirection = transform.right * moveSpeed * horizontal;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        // Apply gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the character using the Character Controller
        characterController.SimpleMove(moveDirection);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isRightWalking", isRightWalking);
        animator.SetBool("isLeftWalking", isLeftWalking);
        animator.SetBool("isBackWalking", isBackWalking);
    }
}
