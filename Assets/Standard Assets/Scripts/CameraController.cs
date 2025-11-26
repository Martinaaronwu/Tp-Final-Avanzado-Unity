using UnityEngine;

public class CameraControllerFreeLook : MonoBehaviour
{
    public Transform playerBody;
    public float sensitivity = 200f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // rotación vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // rotación horizontal solo para la cámara
        yRotation += mouseX;

        // aplicamos rotación libre a la cámara (pitch + yaw)
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    // Si querés que el player gire cuando tocás una tecla (ej: click derecho)
    // agregá esto y llamalo desde Update si querés:
    public void RotatePlayerWithCamera()
    {
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
