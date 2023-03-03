using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour, IMovePlayerController, IRotatePlayerController
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    private float _horizontalInput, _verticalInput;
    private float _horizontalMouseInput, _verticalMouseInput;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        //Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? runningSpeed : walkingSpeed) * _horizontalInput;
        float curSpeedY = (isRunning ? runningSpeed : walkingSpeed) * _verticalInput;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


            moveDirection.y = movementDirectionY;
        

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation

        rotationX += -_verticalMouseInput * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, _horizontalMouseInput * lookSpeed, 0);
        
    }


    public void Jump()
    {
        if (characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
    }

    public void HorizontalMove(float MoveType)
    {
        _verticalInput = MoveType;
    }

    public void VerticalMove(float MoveType)
    {
        _horizontalInput = MoveType;
    }

    public void HorizontalRotate(float RotateType)
    {
        _horizontalMouseInput = RotateType;
    }

    public void VerticalRotate(float RotateType)
    {
        _verticalMouseInput = RotateType;
    }
}