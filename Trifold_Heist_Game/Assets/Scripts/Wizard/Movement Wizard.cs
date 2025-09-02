using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Wizard : MonoBehaviour
{
    public float movementSpeed = 7f;
    public float fallGravityMultiplier = 2f;

    public float mouseSensitivity = 2f;
    public float pitchRange = 60f;
    private float rotateCameraPitch;
    private Camera firstPersonCam;

    private float forwardInputValue;
    private float strafeInputValue;

    private float verticalVelocity;

    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        firstPersonCam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        forwardInputValue = Input.GetAxisRaw("Vertical");
        strafeInputValue = Input.GetAxisRaw("Horizontal");

        Movement();
        CameraMovement();
    }

    void Movement()
    {
        Vector3 direction = (transform.forward * forwardInputValue
                            + transform.right * strafeInputValue).normalized
                            * movementSpeed * Time.deltaTime;

        direction += Vector3.up * verticalVelocity * Time.deltaTime;

        characterController.Move(direction);
    }
    void CameraMovement()
    {
        float rotateYaw = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotateYaw, 0);

        rotateCameraPitch += -Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotateCameraPitch = Mathf.Clamp(rotateCameraPitch, -pitchRange, pitchRange);
        firstPersonCam.transform.localRotation = Quaternion.Euler(rotateCameraPitch, 0, 0);
    }
}