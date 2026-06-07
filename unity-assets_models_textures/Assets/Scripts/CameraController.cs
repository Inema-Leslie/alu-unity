using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;        // The player to follow
    public float distance = 5f;     // Distance behind player
    public float height = 2f;       // Height above player
    public float mouseSensitivity = 3f;

    private float yaw = 0f;         // Left/right rotation
    private float pitch = 20f;      // Up/down rotation

    void LateUpdate()
    {
        bool isRightClickHeld = Input.GetMouseButton(1);
        bool isFreeLook = !Input.GetMouseButton(1);

        // Rotate camera with mouse movement OR right-click drag
        if (isFreeLook || isRightClickHeld)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -10f, 60f); // Limit up/down angle
        }

        // Calculate camera position behind and above player
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        transform.position = player.position + Vector3.up * height + offset;

        // Always look at the player
        transform.LookAt(player.position + Vector3.up * 1f);
    }
}