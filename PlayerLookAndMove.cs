using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAndMove : MonoBehaviour
{

    
    public CharacterController controller;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public float gravity = -9.81f;
    public float walkSpeed = 15f;
    Vector3 velocity = Vector3.zero;
    float x;
    float z;
    Vector3 rVector;



    public Animator cameraAnimator;
    public Animator gunAnimator;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //cursor locked in the center of the screen
    }



    void FixedUpdate()
    {
        mouseLook();
        playerMovement();
    }

    public void mouseLook(){

        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // xRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // playerBody.Rotate(Vector3.up * mouseX);

        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        xRotation += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
     
        // clamp the vertical rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
     
        // rotate the camera
        transform.eulerAngles = new Vector3(-xRotation, transform.eulerAngles.y + y, 0);


    }

    public void playerMovement(){

        // isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        // if(isGrounded && velocity.y < 0)
        // {
        //     velocity.y = 0f;
        // }

        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            rVector = transform.right * x + transform.forward * z;
            controller.Move(rVector * walkSpeed * Time.deltaTime);

            cameraAnimator.SetBool("isPlayerWalking", true);
            gunAnimator.SetBool("isPlayerWalking", true);
            

        } else {

            cameraAnimator.SetBool("isPlayerWalking", false);
            gunAnimator.SetBool("isPlayerWalking", false);

        }
        // if(Input.GetButtonDown("Jump") && isGrounded)
        // {   
        //     print("jump now");
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        // 

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity);



    }

}
