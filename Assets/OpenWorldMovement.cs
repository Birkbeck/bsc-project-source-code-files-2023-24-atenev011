using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class OpenWorldMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float runSpeed = 6.0f;

    private CharacterController characterController;
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);

        float movementSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveDirection = forward * vertical + right * horizontal;
        moveDirection.y = 0;
        moveDirection.Normalize();

        // Update Animator parameters
        float moveThreshold = 0.1f;
        bool isWalking = Mathf.Abs(horizontal) > moveThreshold || Mathf.Abs(vertical) > moveThreshold && !isRunning;
        bool isSideWalkingRight = horizontal > moveThreshold && Mathf.Abs(vertical) < moveThreshold;
        bool isSideWalkingLeft = horizontal < -moveThreshold && Mathf.Abs(vertical) < moveThreshold;
        bool isBackWalking = vertical < -moveThreshold;

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isBackWalking", isBackWalking);
        animator.SetBool("isRightWalking", isSideWalkingRight);
        animator.SetBool("isLeftWalking", isSideWalkingLeft);

        // Transition from Walk to Run
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") && isRunning)
        {
            animator.SetTrigger("toRun");
        }
    }

    private void FixedUpdate()
    {
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) ? runSpeed : walkSpeed;

        characterController.SimpleMove(moveDirection * movementSpeed);
    }
}
