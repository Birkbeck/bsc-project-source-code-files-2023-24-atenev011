using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public void Move(Rigidbody rb, float moveSpeed);
}
