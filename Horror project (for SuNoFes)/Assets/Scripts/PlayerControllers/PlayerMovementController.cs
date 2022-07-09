using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Camera playerCamera;

    private Animator cameraAnimator;

    private bool isCrouching;
    private bool isRunning;

    [HideInInspector] public Vector3 movingSpeed;

    public CapsuleCollider standingCollider;
    public CapsuleCollider crouchingCollider;

    public float speed;
    public float sideSpeed;

    public float crouchSpeedMul;
    public float runSpeedMul;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        playerCamera = Component.FindObjectOfType<Camera>();
        cameraAnimator = playerCamera.GetComponent<Animator>();

        isCrouching = false;
        isRunning = false;
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) { isCrouching = true; ChangeCrouchState(); }
        if (Input.GetKeyUp(KeyCode.LeftControl)) { isCrouching = false; ChangeCrouchState(); }

        if (Input.GetKeyDown(KeyCode.LeftShift)) { isRunning = true; ChangeRunningState(); }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { isRunning = false; ChangeRunningState(); }

    }

    //Changing player states
    private void ChangeCrouchState()
    {
        if (isCrouching) {
            playerCamera.transform.position -= new Vector3(0.0f, 0.8f, 0.0f);

            standingCollider.enabled = false;
            crouchingCollider.enabled = true;

            speed *= crouchSpeedMul;
            sideSpeed *= crouchSpeedMul;

            cameraAnimator.SetBool("isCrouching", true);
        } else if (!isCrouching) {
            playerCamera.transform.position += new Vector3(0.0f, 0.8f, 0.0f);

            standingCollider.enabled = true;
            crouchingCollider.enabled = false;

            speed /= crouchSpeedMul;
            sideSpeed /= crouchSpeedMul;
            cameraAnimator.SetBool("isCrouching", false);
        }
    }

    private void ChangeRunningState()
    {
        if (isRunning) {
            speed *= runSpeedMul;
            sideSpeed *= runSpeedMul;
        } else if (!isRunning) {
            speed /= runSpeedMul;
            sideSpeed /= runSpeedMul;
        }
    }

    //Gets Input and moves player
    private void MovementLogic()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 horizontalMove = Vector3.right * horizontalInput * sideSpeed;
        Vector3 vertcalMove = Vector3.forward * verticalInput * speed;

        movingSpeed = horizontalMove + vertcalMove;

        transform.Translate(movingSpeed);
    }
}
