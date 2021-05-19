using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    //Camera
    public Transform cam;
    public float speed = 0.5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    //Player
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed;
    private float walkSpeed = 2.0f;
    private float jumpHeight = 3.0f;
    private float gravityValue = -9.81f;
    private float runSpeed = 4.0f;
    private float crawlSpeed = 1.0f;

    void Start()
    {
        playerSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Atan2 is a mathematical funcion that returns the angle between the x-axis and a vector starting at 0 and terminating at x comma y
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        //Player speed
        if(Input.GetKey("left shift"))
        {
            playerSpeed = runSpeed;
        }
        if(!Input.GetKey("left shift"))
        {
            playerSpeed = walkSpeed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerSpeed = crawlSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            playerSpeed = walkSpeed;
        }
    }
}
