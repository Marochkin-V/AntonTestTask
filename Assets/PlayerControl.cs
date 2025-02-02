using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        characterController = GetComponent<CharacterController>();

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
    }

    public void MovePlayer(Vector3 dir)
    {
        velocityDirection.x = dir.x * moveSpeed;
        characterController.Move(velocityDirection * Time.deltaTime);
    }

    public void RotatePlayer(Vector3 dir)
    {
        if (characterController.isGrounded)
        {
            if(Vector3.Angle(transform.forward, dir) > 0)
            {
                Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDir);
            }
        }
    }
}
