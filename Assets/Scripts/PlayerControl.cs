using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float rotateSpeed;

    [SerializeField] private float maxJumpTime;
    [SerializeField] private float maxJumpHeight;
    private float startJumpVelocity;
 
    [SerializeField] private float gravityForce = 9.8f;
    public float GravityForce
    {
        set
        {
            if (value >= 0)
                gravityForce = value;
        }
    }

    private CharacterController characterController;

    [HideInInspector]public Vector3 velocityDirection;

    [SerializeField] private Animator anim;


    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Calculations for jumping
        float maxHeightTime = maxJumpTime / 2;
        gravityForce = (2 * maxJumpHeight) / Mathf.Pow(maxHeightTime, 2);
        startJumpVelocity = (2 * maxJumpHeight) / maxHeightTime;
    }

    void Update()
    {
        // Gravity
        if (!characterController.isGrounded)
        {
            velocityDirection.y -= gravityForce * Time.deltaTime;
        }
        else
        {
            velocityDirection.y = -0.5f;
        }

        //HandleJump
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            velocityDirection.y = startJumpVelocity;
        }

        // Moving
        MovePlayer(new Vector3(Input.GetAxis("Horizontal"), 0, 0));

        // Rotate
        RotatePlayer(new Vector3(velocityDirection.x, 0, 0));

        // Animations
        anim.SetBool("Grounded", characterController.isGrounded);
        anim.SetBool("Jump", velocityDirection.y != -0.5f);
        anim.SetBool("FreeFall", velocityDirection.y < 0 && velocityDirection.y > -0.5f);
        anim.SetFloat("Speed", Mathf.Abs(velocityDirection.x));
    }

    public void MovePlayer(Vector3 dir)
    {
        velocityDirection.x = dir.x * moveSpeed;
        characterController.Move(velocityDirection * Time.deltaTime);
    }

    public void RotatePlayer(Vector3 dir)
    {
        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
