using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float rotationSpeed = 360.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private bool isJumping = false;
    private Camera mainCamera;
    float mouseX = 0f;
    float mouseY = 0f;
    private CharacterController controller;

    void Start()
    {
        mainCamera = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check for sprint input
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 5.0f;
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }

        // Apply gravity over time if not grounded
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (controller.isGrounded && isJumping)
        {
            // Reset isJumping if grounded
            isJumping = false;
        }

        // Crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1.5f; // Set to half height or a value suitable for your character model
        }
        else
        {
            controller.height = 2.0f; // Reset to full height
        }

        // Get the input
        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        // Calculate the move direction relative to the camera's rotation
        Vector3 move = transform.right * moveLR + transform.forward * moveFB;

        // Move the character
        controller.Move(speed * Time.deltaTime * move);
        controller.Move(velocity * Time.deltaTime);

        // Rotate character based on mouse movement
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -70, 70);
        transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}