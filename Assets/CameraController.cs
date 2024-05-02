using UnityEngine;

public class CameraController : MonoBehaviour
{
public Transform cameraPivot;
public float cameraDistance = 10.0f;
public float cameraHeight = 2.0f;
public float cameraAngle = 30.0f;
public float cameraFollowSpeed = 5.0f;
private Vector3 targetPosition;

void Start()
{
    targetPosition = cameraPivot.position;
}

void LateUpdate()
{
    // Update Target Position
    targetPosition = Vector3.Lerp(targetPosition, cameraPivot.position, Time.deltaTime * cameraFollowSpeed);

    // Calculate Camera Position and Rotation
    float radians = cameraAngle * Mathf.Deg2Rad;
    float horizontalDistance = cameraDistance * Mathf.Cos(radians);
    float verticalDistance = cameraDistance * Mathf.Sin(radians);

    Vector3 cameraPosition = targetPosition;
    cameraPosition -= cameraPivot.forward * horizontalDistance;
    cameraPosition.y += verticalDistance + cameraHeight;

    Quaternion cameraRotation = Quaternion.LookRotation(targetPosition - cameraPosition, Vector3.up);

    // Update Camera Position and Rotation
    transform.position = cameraPosition;
    transform.rotation = cameraRotation;
}
}