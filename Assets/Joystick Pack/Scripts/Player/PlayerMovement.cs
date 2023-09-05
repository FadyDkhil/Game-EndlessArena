using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider)) ]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public FixedJoystick _joystick;
    public Animator _animation;
    public Rigidbody _rb;
    private Animator animator;
    public GameObject Player;
    private PlayerController pc;

    void Start()
    {
        pc = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate(){
       Vector3 inputDirection = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
       
         if (inputDirection.magnitude > 0)
        {
            pc.SwordAttacking = false;
            // Calculate the rotation angle based on the input direction
            float targetRotationAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;

            // Smoothly rotate the character towards the target rotation angle
            Quaternion targetRotation = Quaternion.Euler(0f, targetRotationAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 6.6f);
            animator.SetBool("isMoving", true);
            _rb.velocity = new Vector3(inputDirection.x * speed, _rb.velocity.y, inputDirection.z * speed);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
       
    }
    }



