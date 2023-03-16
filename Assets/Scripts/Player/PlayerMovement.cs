using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("SerializeFields")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    // horizontal
    private float horizontal;

    [Header("Stats")]
    private float speed = 8f;

    // jump
    private float jumpPower = 24f;

    public float jumpStartTime;
    private float jumpTime;
    private bool isJump;

    // flip
    private bool right = true;

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        
        playerFlip();

        Jump();
    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void playerFlip()
    {

        if (right && horizontal < 0f || !right && horizontal > 0f)
        {

            right = !right;

            Vector3 scal = transform.localScale;
            scal.x *= -1;
            transform.localScale = scal;
        }
    }

    private bool grounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump") && grounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
}