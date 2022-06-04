using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator anim;
    float hor = 0;
    float ver = 0;
    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        
        if (anim.GetFloat("Speed") > 0)
        {
            anim.Play("Movement");
            hor = anim.GetFloat("Horizontal");
            ver = anim.GetFloat("Vertical");
        }
        if (anim.GetFloat("Speed") < 0.01)
        {
            
            if (hor > 0 && Math.Abs(ver) < hor) {
                anim.Play("Idle Right");
            }
            else if (hor < 0 && Math.Abs(hor) > Math.Abs(ver))
            {
                anim.Play("Idle Left");
            }
            else if (ver > 0 && ver > Math.Abs(hor))
            {
                anim.Play("Idle Up");
            }
            else
            {
                anim.Play("Idle");
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
