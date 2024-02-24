using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public int maxJumps = 2; // Número máximo de saltos, incluido el terrestre.

    private Rigidbody rb;
    private bool isGrounded;
    private bool isRunning;
    private int jumpsRemaining;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        // Movimiento horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * (isRunning ? runSpeed : moveSpeed) * Time.deltaTime;
        transform.Translate(movement);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpsRemaining > 0))
        {
            if (!isGrounded)
                jumpsRemaining--;

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Correr
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    void OnCollisionStay(Collision collision)
    {
        // Verificar si el jugador está en el suelo y restablecer los saltos disponibles
        isGrounded = true;
        jumpsRemaining = maxJumps - 1; // Restablecer los saltos disponibles al suelo.
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
