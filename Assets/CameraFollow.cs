/// <summary>
/// Author: atenev01
/// Class for camera following the player.
/// </summary>

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Target to follow
    public Transform headTarget; // Target for camera rotation
    public float distance = 4f; // Distance from target
    public float adjustableHeight = 1.8f; // Height offset
    public float smoothSpeed = 5f; // Camera movement speed
    public Vector2 rotationMinMax = new Vector2(-40, 80); // Min and max rotation angles
    public float rotationSpeed = 3f; // Rotation speed
    public float zoomSpeed = 10f; // Zoom speed
    public Vector2 distanceMinMax = new Vector2(2f, 10f); // Min and max distance from target
    public LayerMask terrainLayerMask; // Layer mask for terrain
    public float terrainOffset = 1f; // Offset for terrain detection
    public Vector2 fovMinMax = new Vector2(30, 60); // Min and max FOV

    private Vector3 currentVelocity; // Current camera velocity
    private float rotationX; // X rotation
    private float rotationY; // Y rotation

    public static Camera MainCamera { get; private set; } // Reference to main camera

    private void Awake()
    {
        MainCamera = GetComponentInChildren<Camera>(); // Get main camera component
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to screen
        Cursor.visible = false; // Hide cursor
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // If right mouse button is pressed
        {
            rotationY += Input.GetAxis("Mouse X") * rotationSpeed; // Update Y rotation
            rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed; // Update X rotation

            RaycastHit hitInfo;
            float terrainDistance = Physics.Raycast(target.position, Vector3.down, out hitInfo, Mathf.Infinity, terrainLayerMask) ? hitInfo.distance : Mathf.Infinity;

            if (distance > 4f && terrainDistance < 2f)
            {
                rotationX = Mathf.Clamp(rotationX, rotationMinMax.x, Mathf.Min(rotationX, rotationMinMax.y)); // Clamp X rotation
            }
            else
            {
                rotationX = Mathf.Clamp(rotationX, rotationMinMax.x, rotationMinMax.y); // Clamp X rotation
            }
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel"); // Get scroll input
        distance -= scrollInput * zoomSpeed; // Update distance
        distance = Mathf.Clamp(distance, distanceMinMax.x, distanceMinMax.y); // Clamp distance

        MainCamera.fieldOfView = Mathf.Lerp(fovMinMax.y, fovMinMax.x, (distance - distanceMinMax.x) / (distanceMinMax.y - distanceMinMax.x)); // Update FOV

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0); // Calculate rotation

        Vector3 targetPosition = headTarget.position - (rotation * Vector3.forward * distance) + (Vector3.up * adjustableHeight); // Calculate target position

        RaycastHit hit;
        if (Physics.Raycast(target.position, (targetPosition - target.position).normalized, out hit, distance, terrainLayerMask)) // If raycast hits terrain
        {
            targetPosition = hit.point + hit.normal * terrainOffset; // Update target position with terrain offset
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed * Time.deltaTime); // Move camera

        transform.LookAt(headTarget); // Look at head target
    }
}
