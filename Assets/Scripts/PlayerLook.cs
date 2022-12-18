using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSense = 2f;
    private float rotateX;
    private float rotateY;
    public Transform Camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        rotateX += Input.GetAxis("Mouse X") * mouseSense;
        rotateY += Input.GetAxis("Mouse Y") * mouseSense;
        rotateY = Mathf.Clamp(rotateY, -90f, 90f);

        transform.transform.rotation = Quaternion.Euler(0f, rotateX, 0f);
        Camera.transform.rotation = Quaternion.Euler(-rotateY, rotateX, 0f);
    }
}