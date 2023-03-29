using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    private float jumpHeight = 1f;
     
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Animator animator;
    private float walkSpeed = 5;
    private float runSpeed = 8; 
    // private Vector2 turn;
    // public float m_mouseSensitivy = 2f;
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    public void FixedUpdate()
    {
       ProcessMovement();
       UpdateAnimator();
    //    turn.x = Input.GetAxis("Mouse X");
    //    turn.y = Input.GetAxis("Mouse Y");
    //    transform.Rotate(0, turn.x* m_mouseSensitivy, 0, Space.Self);
       
    }
    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }
    void UpdateAnimator()
    {
        // Do Roll
        if (Input.GetButtonDown("Fire2"))
        {
            animator.applyRootMotion = true; 
            animator.SetTrigger("DoRoll");
        }
        
        // Movement
        if (Mathf.Abs(Input.GetAxis("Horizontal"))>0.0f || Mathf.Abs(Input.GetAxis("Vertical"))>0.0f)
        {
            if (Input.GetButton("Fire3"))// Left shift
            {
                animator.SetFloat("CharacterSpeed",1.0f);
            }
            else
            {
                animator.SetFloat("CharacterSpeed",0.5f);
            }
        }
        else 
        {
            animator.SetFloat("CharacterSpeed",0.0f);

        }
        
        // Is Grounded
        animator.SetBool("IsGrounded",groundedPlayer);
        
    }

 

   void ProcessMovement()
{
float speed = GetMovementSpeed();
Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

// Turning the character
if (move != Vector3.zero)
{
    transform.forward = move;
}

// Check for jump input
if (Input.GetButtonDown("Jump") && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 0.01f)
{
    GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
}

// Apply gravity
GetComponent<Rigidbody>().AddForce(Vector3.down * gravityValue, ForceMode.Acceleration);

// Limit the velocity so it doesn't get too fast
if (GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
{
    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
}
GetComponent<Rigidbody>().MovePosition(transform.position + move * speed * Time.deltaTime);
}

// Move the player


    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
