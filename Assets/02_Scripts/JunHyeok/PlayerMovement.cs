using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;

    public float boostSpeed = 1f;
    public float boostTime = 0f;
    public float time;

    private CharacterController characterController;
    public Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    [HideInInspector]
    private bool canMove = true;

    void Awake()
    {

        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        PlayerMoveAndJump();
        PlayerBoostUp();
    }

    void PlayerMoveAndJump()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? walkingSpeed * boostSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? walkingSpeed * boostSpeed * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {

            moveDirection.y = jumpSpeed;

        }
        else
        {

            moveDirection.y = movementDirectionY;

        }

        if (!characterController.isGrounded)
        {

            moveDirection.y -= gravity * Time.deltaTime;

        }


        characterController.Move(moveDirection * Time.deltaTime);


        if (canMove)
        {

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        }
    }

    public void PlayerBoostUp()
    {
        if (boostSpeed != 1f)
        {
            time += Time.deltaTime;
            if (time > boostTime)
            {
                boostSpeed = 1f;
            }
        }
        else
        {
            time = 0;
        }
    }
}