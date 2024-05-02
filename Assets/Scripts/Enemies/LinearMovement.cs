using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : IMovement
{
    private Vector3 movementDirection = Random.onUnitSphere;

    public void Move(Rigidbody rb, float moveSpeed)
    {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
