using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal"); // A and D
        float moveZ = Input.GetAxis("Vertical");   // W and S

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        move.y = rb.linearVelocity.y;
        rb.linearVelocity = move;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if player is on the ground or a platform
        isGrounded = true;
    }
}