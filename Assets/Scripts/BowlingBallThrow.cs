using UnityEngine;

public class BowlingBallThrow : MonoBehaviour
{
    public float forwardMultiplier = 6f;
    public float maxSpeed = 6f;

    [Header("Dirección")]
    public float maxAngle = 15f;      // grados máximos de diagonal
    public float horizontalSensitivity = 0.15f;

    private Rigidbody rb;
    private Vector3 mouseStart;
    private bool canThrow = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (!canThrow) return;

        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouseEnd = Input.mousePosition;
            Throw(mouseEnd);
            canThrow = false;
        }
    }

    void FixedUpdate()
    {
        if (!rb.isKinematic)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void Throw(Vector3 mouseEnd)
    {
        Vector3 drag = mouseEnd - mouseStart;

        // Fuerza hacia adelante
        float forwardForce = Mathf.Clamp(-drag.y, 0f, 300f) * forwardMultiplier;

        // Ángulo según movimiento horizontal del mouse
        float angle = Mathf.Clamp(
            drag.x * horizontalSensitivity,
            -maxAngle,
            maxAngle
        );

        rb.isKinematic = false;

        // Rotamos la dirección hacia izquierda/derecha
        Vector3 direction = Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;

        rb.AddForce(direction * forwardForce, ForceMode.Force);
    }
}
