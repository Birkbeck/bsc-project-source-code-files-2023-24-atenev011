using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float hitForce = 50f;
    public float maxHealth = 100f;
    public float currentHealth;
    public AnimationManagerUI animManager;

    private Rigidbody rb;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Check if player is grounded
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 1f);

        // Handle movement
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Handle attacks
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animManager.SetAnimation_Hit01();
            Attack(hitForce);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animManager.SetAnimation_Hit02();
            Attack(hitForce);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animManager.SetAnimation_Hit03();
            Attack(hitForce);
        }

        // Handle taking damage and KO
        if (currentHealth <= 0f)
        {
            animManager.SetAnimation_KO();
            // Code to trigger when player gets KO
        }
    }

    private void Attack(float force)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                enemy.TakeDamage(force);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        animManager.SetAnimation_Damage();
        // Code to trigger when player takes damage
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            animManager.SetAnimation_KO();
            // Code to trigger when player gets KO
        }
    }
}
