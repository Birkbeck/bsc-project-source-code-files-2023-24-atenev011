using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Player movement speed
    public float jumpForce = 10.0f; // Jump force
    public float groundCheckRadius = 0.2f; // Radius of ground check sphere
    public Transform groundCheck; // Transform of ground check object
    public LayerMask groundLayer; // Layer mask for the ground layer

    private Rigidbody rb; // Rigidbody component of the character
    private Animator anim; // Animator component of the character
    private bool isGrounded; // Whether the character is grounded or not

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        rb.AddForce(movement * moveSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        anim.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * Physics.gravity.y);
        }
    }
}
