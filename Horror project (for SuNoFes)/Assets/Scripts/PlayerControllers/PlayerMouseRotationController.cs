using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseRotationController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Camera playerCamera;

    private float maxYRotation = 60;

    public float mouseXRotation;
    public float mouseYRotation;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCamera = Component.FindObjectOfType<Camera>();

        mouseXRotation = GameObject.FindGameObjectWithTag("EventManager").GetComponent<ButtonsControllers>().mouseSensetivity;
        mouseYRotation = mouseXRotation / 2 + mouseXRotation / 3;
    }

    private void LateUpdate()
    {
        MouseXRotation();
        MouseYRotation();
    }

    //Rotates camera around Y axis
    private void MouseXRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");

        playerRb.rotation *= Quaternion.Euler(0.0f, mouseX * mouseXRotation * Time.deltaTime, 0.0f);
    }

    //Rotates camera around X axis
    private void MouseYRotation()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 euler = playerCamera.transform.localEulerAngles;
        euler.x -= mouseY * mouseYRotation * Time.deltaTime;

        if (euler.x > maxYRotation && euler.x < 180) euler.x = maxYRotation;

        playerCamera.transform.localEulerAngles = euler;
    }
}
