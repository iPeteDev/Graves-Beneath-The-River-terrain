using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    private Vector3 lastMousePosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Save mouse position when starting to rotate
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            // Hide cursor while rotating
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

            // Keep mouse at last position so it doesnt snap to center
            Mouse.current?.WarpCursorPosition(lastMousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Show cursor and restore position when done rotating
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}