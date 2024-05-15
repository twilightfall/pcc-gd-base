using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Setup Variables")]
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    Player player;

    // Controller Variables
    [Header("Controller")]
    bool isControllerConnected;
    //Gamepad gamepad;

    // Movement Variables
    [Header("Movement")]
    float moveSpeed;
    float horizontal, vertical;
    Vector3 velocity = new();

    // Jump Variables
    float jumpForce;
    public static bool canJump = true;

    // Ground Check
    [Header("Gravity Variables")]
    [SerializeField]
    float distance;
    [SerializeField]
    Vector3 size;
    bool isGrounded;
    bool isJumping;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        moveSpeed = player.MoveSpeed;
        jumpForce = player.JumpForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position-transform.up*distance, size);
    }

    // Update is called once per frame
    void Update()
    {
        //gamepad = Gamepad.current;
        //if (gamepad == null)
        isControllerConnected = false;
        //else
        //    isControllerConnected = true;

        GravityCheck();

        Jump();
        UpdateMove();
    }


    void UpdateMove()
    {
        if (isControllerConnected == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector3 movement = new(horizontal, 0f, vertical);

            if (movement != Vector3.zero) transform.rotation = Quaternion.LookRotation(movement);
            controller.Move(moveSpeed * Time.deltaTime * movement);
        }
        //else
        //{
        //    Vector2 moveVector = gamepad.leftStick.ReadValue();

        //    Vector3 movement = transform.right * moveVector.x + transform.forward * moveVector.y;

        //    controller.Move(movement * 5f * Time.deltaTime);
        //}
    }

    void GravityCheck()
    {
        if (Physics.BoxCast(transform.position, size, Vector3.down, out RaycastHit hit, transform.rotation, distance, groundMask))
        {
            isGrounded = true;
            isJumping = false;
            //print("grounded");
            velocity.y = 0;
        }
        else
        {
            isGrounded = false;
            isJumping = true;
            //print("not grounded");
            velocity.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        //isGrounded = Physics.CheckSphere(groundCheck.position, .5f, groundMask);

        //if (isGrounded & velocity.y < 0f)
        //{
        //    isJumping = false;
        //    velocity.y = -1f;
        //}
        //else
        //{
        //    isJumping = true;
        //    velocity.y += Physics.gravity.y * Time.deltaTime;
        //    controller.Move(velocity * Time.deltaTime);
        //}
    }

    void Jump()
    {
        if (canJump == true)
        {
            if (isControllerConnected == false)
            {
                if (Input.GetButtonDown("Jump") && isGrounded && !isJumping)
                {
                    UIPlayerController.instance.ShowPlayerStats();
                    isGrounded = false;
                    isJumping = true;

                    velocity.y = Mathf.Sqrt(2f * -2f * Physics.gravity.y);
                    controller.Move(velocity * Time.deltaTime);
                }
            }
            //else
            //{
            //    if (gamepad.aButton.wasPressedThisFrame && isGrounded && !isJumping)
            //    {
            //        isGrounded = false;
            //        isJumping = true;

            //        velocity.y = Mathf.Sqrt(2f * -2f * Physics.gravity.y);
            //        controller.Move(velocity * Time.deltaTime);
            //    }
            //}
        }
    }
}
