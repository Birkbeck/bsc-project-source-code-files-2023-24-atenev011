using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 4f;
    public float height = 2f;
    public float smoothSpeed = 5f;
    public Vector2 rotationMinMax = new Vector2(-40, 80);
    public float rotationSpeed = 3f;
    public float zoomSpeed = 10f;
    public Vector2 distanceMinMax = new Vector2(2f, 10f);
    public LayerMask terrainLayerMask;
    public float terrainOffset = 1f;

    private Vector3 currentVelocity;
    private float rotationX;
    private float rotationY;

    public static Camera MainCamera { get; private set; }

    private void Awake()
    {
        MainCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            rotationY += Input.GetAxis("Mouse X") * rotationSpeed;
            rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
            rotationX = Mathf.Clamp(rotationX, rotationMinMax.x, rotationMinMax.y);
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        distance -= scrollInput * zoomSpeed;
        distance = Mathf.Clamp(distance, distanceMinMax.x, distanceMinMax.y);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);

        Vector3 targetPosition = target.position - (rotation * Vector3.forward * distance) + (Vector3.up * height);

        RaycastHit hit;
        if (Physics.Raycast(target.position, (targetPosition - target.position).normalized, out hit, distance, terrainLayerMask))
        {
            targetPosition = hit.point + hit.normal * terrainOffset;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed * Time.deltaTime);

        transform.LookAt(target);
    }
}
