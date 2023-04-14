using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCameraYZAxis : MonoBehaviour
{
    //public float GetYRotation() { 
    //    return transform.rotation.y;
    //} 

    //public float YRotation {
    //    get { return transform.rotation.y; }
    //}

    public Transform playerBody;

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime  * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensX;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
        //yRotation = Mathf.Clamp(yRotation, -70f, 70f);
        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
