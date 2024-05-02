using UnityEngine;

public enum MovementType
{
    RANDOM,
    LINEAR
}

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public MovementType movementType;

    private IMovement movement; 
    private Rigidbody rb;
    private EnemyAnimation enemyAnimation;

    void Start()
    {
        SetUpMovement();
        rb = GetComponent<Rigidbody>();

        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    void FixedUpdate()
    {
        if (movement != null)
        {
            movement.Move(rb, moveSpeed);
            enemyAnimation.SetRunningState(true);
        }
    }

    void SetUpMovement()
    {
        switch (movementType)
        {
            case MovementType.RANDOM:
                movement = new RandomMovement();
                break;
            case MovementType.LINEAR:
                movement = new LinearMovement();
                break;
        }
    }
}
