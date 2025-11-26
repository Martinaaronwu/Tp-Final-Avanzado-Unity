using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 50f;   // fuerza base para mover
    public float maxSpeed = 6f;     // limita la velocidad para que no se vuelva incontrolable
    public float airMultiplier = 0.5f; // control en el aire

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // evita que se vuelque por física
    }

    void Update()
    {
        // chequeamos si está tocando el piso
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = (transform.forward * z + transform.right * x).normalized;

        if (direction.magnitude > 0)
        {
            float multiplier = isGrounded ? 1f : airMultiplier;

            // Aplicamos fuerza
            rb.AddForce(direction * moveForce * multiplier, ForceMode.Acceleration);
        }

        // Limitar velocidad máxima
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
