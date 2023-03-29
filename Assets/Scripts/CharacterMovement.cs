using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{

 public Text jumpText;
    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer = true;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Animator animator;
    private float walkSpeed = 5;
    private float runSpeed = 8; 
    bool canDoubleJump = true;
    bool checkBoosted;

    
    
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        
    }

    public void Update()
    {
       ProcessMovement();
       UpdateAnimator();
       
       
    }

    void UpdateAnimator()
    {

        
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
        
  
           animator.SetBool("IsGrounded",groundedPlayer);
     
    }

  


void ProcessMovement()
{ 
    // Moving the character forward according to the speed
    float speed = GetMovementSpeed();

    // Get the camera's forward vector
    Vector3 cameraForward = Camera.main.transform.forward;
    cameraForward.y = 0f;
    cameraForward.Normalize();

    // Calculate the move direction based on the camera's forward vector and the input
    Vector3 move = (Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * cameraForward).normalized;

    // Turn the character towards the move direction
    if (move != Vector3.zero)
    {
        gameObject.transform.forward = move;
    }

    // Making sure we dont have a Y velocity if we are grounded
    // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
    groundedPlayer = controller.isGrounded;
    if (groundedPlayer)
    {
        canDoubleJump = true;

        if (Input.GetButtonDown("Jump") )
        {
          
            gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            canDoubleJump = true;
        }
        else 
        {
            // Dont apply gravity if grounded and not jumping
            gravity.y = -1.0f;
        }
    }
    else 
    {
        // If the player can double jump, allow them to jump again

        if (Input.GetButtonDown("Jump") && canDoubleJump && checkBoosted)
        {
        
            gravity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            canDoubleJump = false;
            checkBoosted = false;
            GameManager.Instance.UpdateJumpText(false);
            animator.SetTrigger("Flip");
            GetComponent<ParticleSystem>().Play();
            
        }
        else
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }  
    }

    playerVelocity = gravity * Time.deltaTime + move * Time.deltaTime * speed;
    controller.Move(playerVelocity);
}


        void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boost")
        {
            checkBoosted = true; 
        }


    }
    

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
