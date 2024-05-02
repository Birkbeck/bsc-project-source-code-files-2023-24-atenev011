using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : IMovement
{
    public float changeDirectionInterval = 2f;
    public float maxDirectionChangeAngle = 360;

    private Vector3 movementDirection;
    private float timeSinceLastDirectionChange = 0f;

    public void Move(Rigidbody rb, float moveSpeed)
    {
        timeSinceLastDirectionChange += Time.fixedDeltaTime;
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            Quaternion randomRotation = Quaternion.Euler(Random.insideUnitSphere * maxDirectionChangeAngle);
            movementDirection = randomRotation * rb.transform.forward;
            timeSinceLastDirectionChange = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(movementDirection.x, 0f, movementDirection.z));
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, Time.fixedDeltaTime * 5f));
        }

        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
