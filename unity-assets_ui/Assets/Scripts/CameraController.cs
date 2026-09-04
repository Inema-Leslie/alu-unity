using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance = 5f;
    public float height = 2f;
    public float mouseSensitivity = 3f;

    private float yaw = 0f;
    private float pitch = 20f;
    private PlayerController playerController;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    void LateUpdate()
    {
        // Smoothly follow player including during respawn
        bool isRightClickHeld = Input.GetMouseButton(1);
        bool isFreeLook = !Input.GetMouseButton(1);

        if (isFreeLook || isRightClickHeld)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -10f, 60f);
        }

        // Smoothly follow player position
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        Vector3 targetPosition = player.position + Vector3.up * height + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);

        transform.LookAt(player.position + Vector3.up * 1f);
    }
}