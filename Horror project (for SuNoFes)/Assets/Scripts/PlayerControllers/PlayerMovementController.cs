using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Camera playerCamera;

    private bool isCrouching;

    public CapsuleCollider standingCollider;
    public CapsuleCollider crouchingCollider;

    public float speed;
    public float sideSpeed;

    public float crouchSpeedMul;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        playerCamera = Component.FindObjectOfType<Camera>();
        isCrouching = false;
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) { isCrouching = true; ChangeIdolState(); }
        if (Input.GetKeyUp(KeyCode.LeftControl)) { isCrouching = false; ChangeIdolState(); }

    }

    //Changing states from Standing to Crouching
    private void ChangeIdolState()
    {
        if (isCrouching) {
            playerCamera.transform.position -= new Vector3(0.0f, 0.8f, 0.0f);

            standingCollider.enabled = false;
            crouchingCollider.enabled = true;

            speed *= crouchSpeedMul;
            sideSpeed *= crouchSpeedMul;
        } else if (!isCrouching) {
            playerCamera.transform.position += new Vector3(0.0f, 0.8f, 0.0f);

            standingCollider.enabled = true;
            crouchingCollider.enabled = false;

            speed /= crouchSpeedMul;
            sideSpeed /= crouchSpeedMul;
        }
    }

    //Gets Input and moves player
    private void MovementLogic()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 horizontalMove = Vector3.right * horizontalInput * sideSpeed;
        Vector3 vertcalMove = Vector3.forward * verticalInput * speed;

        Vector3 move = horizontalMove + vertcalMove;

        transform.Translate(move);
    }
}
