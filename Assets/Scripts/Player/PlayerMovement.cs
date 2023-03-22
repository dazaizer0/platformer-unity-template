using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("SerializeFields")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask wall;
    [SerializeField] private TrailRenderer trail;

    // horizontal
    private float horizontal;

    [Header("Movement")]
    private float speed = 9f;

    // jump
    private bool isJump;
    private float jumpPower = 25f;
    public float jumpStartTime;
    private float jumpTime;

    [Header("Dash")]
    // dash forward
    public bool Dashing;
    private bool canDash = true;
    private bool dashing;
    private float dashingPower = 50f;
    private float dashTime = 0.2f;
    private float dashCooldown = 2f;

    // dash up
    private bool dashingUp = false;
    private bool canDashUp = false;
    private int toDashUp = 1;
    private float dashUpPower = 800;

    // wall movement
    private bool wallSlide;
    private bool wallJump;
    private float wallSlideSpeed = 0.3f;
    private float wallJumpDirection;
    private float wallJumpTime = 0.2f;
    private float wallJumpCounter;
    private float wallJumpDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(10f, 18f);

    // flip
    private bool right = true;

    void Update()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        playerFlip();
        WallSlide();

        if (!wallJump) {playerFlip();}
        if(grounded()) {toDashUp = 1; dashingUp = false; canDashUp = false;}
        if(toDashUp == 0) {canDashUp = true;}

        if(dashing || dashingUp){Dashing = true;}
        else{Dashing = false;}
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

    private bool walled()
    {

        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wall);
    }

    public void Jump(InputAction.CallbackContext context) // lookat
    {

        if(!dashingUp)
        {

            toDashUp -= 1;

            if (context.performed && grounded())
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {

                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }

    private void WallSlide()
    {
        
        if (walled() && !grounded() && horizontal != 0f)
        {

            wallSlide = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }else
        {

            wallSlide = false;
        }
    }

    public void WallJump(InputAction.CallbackContext context)
    {

        if (wallSlide)
        {

            wallJump = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpCounter = wallJumpTime;

            CancelInvoke(nameof(StopWallJumping));
        }else
        {

            wallJumpCounter -= Time.deltaTime;
        }

        if (context.performed && wallJumpCounter > 0f)
        {

            wallJump = true;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpCounter = 0f;

            if (transform.localScale.x != wallJumpDirection)
            {

                right = !right;
                Vector3 scale = transform.localScale;
                scale.x *= -1f;
                transform.localScale = scale;
            }
            Invoke(nameof(StopWallJumping), wallJumpDuration);
        }
    }

    private void StopWallJumping()
    {

        wallJump = false;
    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        
        if (!grounded())
        {

            StartCoroutine(Dash());
        }
    }

    public void DashUp(InputAction.CallbackContext context)
    {

        if(context.performed && !dashingUp && !grounded() && canDashUp)
        {

            rb.AddForce(transform.up * dashUpPower * 100);
            dashingUp = true;
        }
    }

    private IEnumerator Dash()
    {

        // bools
        canDash = false;
        dashing = true;

        // dash
        rb.gravityScale = 0f;
        speed = 15f;

        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        trail.emitting = true;

        yield return new WaitForSeconds(dashTime);

        trail.emitting = false;
        rb.gravityScale = 2.8f;
        speed = 9f;
        dashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "ToDestroyBlock" && Dashing)
        {

            Destroy(other.gameObject);
        }
    }
}