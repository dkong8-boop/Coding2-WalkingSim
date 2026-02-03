using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 1000f;

    private float xRotation;

    private void Start()
    {
        xRotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        //Neck Restriction
        xRotation = Mathf.Clamp(xRotation, -76f, 76f);

        //PLayer Rotate
        transform.parent.Rotate(Vector3.up * mouseX);

        //Carmera Rotate
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

