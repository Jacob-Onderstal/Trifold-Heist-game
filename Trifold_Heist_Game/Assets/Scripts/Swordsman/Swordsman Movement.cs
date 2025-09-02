using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman_Movement : MonoBehaviour
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

    //Attack

    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public int attackDamage = 1;

    public LayerMask attackLayer;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

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

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
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

    public void Attack()
    {
        if (!readyToAttack || attacking)
        {
            return;
        }

        readyToAttack = false;
        attacking = true;

        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void AttackRaycast()
    {
        if (Physics.Raycast(firstPersonCam.transform.position, firstPersonCam.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            HitTarget(hit.point);
        }
    }

    void HitTarget(Vector3 pos)
    {
        GameObject GO = Instantiate(pos, Quaternion.identity);
        Destroy(GO, 20);
    }

    private GameObject Instantiate(Vector3 pos, Quaternion identity)
    {
        throw new NotImplementedException();
    }
}