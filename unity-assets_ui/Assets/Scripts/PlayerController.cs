using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float fallThreshold = -10f;  // Y position that triggers reset
    public Transform spawnPoint;         // Where player respawns

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Save start position
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        move.y = rb.linearVelocity.y;
        rb.linearVelocity = move;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Check if player has fallen too far
        if (transform.position.y < fallThreshold)
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Stop all movement
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Move player high above start so it falls down dramatically
        transform.position = new Vector3(
            startPosition.x,
            startPosition.y + 20f,  // Drop from above
            startPosition.z
        );
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}