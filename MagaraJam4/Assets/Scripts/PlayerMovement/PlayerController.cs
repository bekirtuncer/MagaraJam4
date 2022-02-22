using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private Vector3 direc;
    public float speed;
    public float jumpForce;
    public float gravity;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public Transform modelTransform;
    private int doubleJumpLeft = 1;
    private bool canDoubleJump = false;
    private bool jumpCooldown = false;
    private float startZ;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {        
        float hInput = Input.GetAxis("Horizontal");
        //float vInput = Input.GetAxis("Vertical");


        direction.x = hInput * speed;
        //direction.z = vInput * speed;


        if(hInput != 0 )
        {
            modelTransform.rotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
        }

        animator.SetFloat("speed", Mathf.Abs(hInput));
        direction.y += gravity * Time.deltaTime;
        
        bool isGrounded = GetComponent<CharacterController>().velocity.y < 0.5f && Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump") && animator.GetBool("isJumping") != true)
        {
            animator.SetBool("isSliding", false);
            animator.SetBool("isJumping", true);
            direction.y = jumpForce;
            jumpCooldown = true;
            Invoke("DisableJumpCooldown",0.3f);
        }
        
        if(!jumpCooldown && Input.GetButtonDown("Jump") && animator.GetBool("isJumping") && doubleJumpLeft > 0)
        {
            animator.Play("Jump",0,0.0f);
            doubleJumpLeft -= 1;
            direction.y = jumpForce;
        }

        if(isGrounded && !jumpCooldown)
        {
            doubleJumpLeft = 1;
            DisableJumping();
        }

        if(isGrounded && Input.GetButtonDown("Fire1") && animator.GetBool("isSliding") != true)
        {
            animator.SetBool("isSliding", true);
            controller.center = new Vector3(0,-0.5f,0);
            controller.height = 1.0f;
            Invoke("DisableSliding",1.0f);
        }
        
        controller.Move(direction * Time.deltaTime);        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, startZ);
    }

    private void DisableJumpCooldown()
    {
        jumpCooldown = false;
    }

    private void DisableSliding()
    {
        controller.center = new Vector3(0, 0.0f, 0);
        controller.height = 2.0f;
        animator.SetBool("isSliding", false);
    }

    private void DisableJumping()
    {
        animator.SetBool("isJumping", false);
    }
}
