using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("SerializeFields")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private TrailRenderer trail;

    // horizontal
    private float horizontal;

    [Header("Stats")]
    private float speed = 9f;

    // jump
    private float jumpPower = 25f;

    public float jumpStartTime;
    private float jumpTime;
    private bool isJump;

    // dash
    private bool canDash = true;
    private bool dashing;

    private float dashingPower = 50f;
    private float dashTime = 0.3f;
    private float dashCooldown = 0.8f;

    // flip
    private bool right = true;

    void Update()
    {

        //horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        playerFlip();
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

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.performed && grounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Dash(InputAction.CallbackContext context)
    {

        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {

        canDash = false;
        dashing = true;

        float gravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        trail.emitting = true;

        yield return new WaitForSeconds(dashTime);
        trail.emitting = false;
        rb.gravityScale = 2.8f;
        dashing = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}