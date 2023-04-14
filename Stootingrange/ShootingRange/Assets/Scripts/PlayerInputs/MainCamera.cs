using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MainCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    internal float fieldOfView;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = UnityEngine.Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = UnityEngine.Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
