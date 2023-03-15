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
    private bool grounded;

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

    void Jump()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);

        if (grounded && (Input.GetButtonDown("Jump")))
        {

            isJump = true;
            jumpTime = jumpStartTime;
            rb.velocity = Vector2.up * jumpPower;
        }

        if (Input.GetButtonDown("Jump") && isJump == true)
        {

            rb.velocity = Vector2.up * jumpPower;
            jumpTime -= Time.deltaTime;
        }else
        {

            isJump = false;
        }


        if(Input.GetButtonUp("Jump"))
        {

            isJump = false;
        }
    }
}

    // PUBLIC
/*  [Header("Move")]
    public float speed;

    [Header("Jump")]
    public float jump;
    public int extraJumpsValue;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    // PRIVATE
    private int extraJumps;
    private float moveInput;
    private Rigidbody2D rb;
    private bool right = true;

    private bool grounded;



    void Start()
    {

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(right == false && moveInput > 0)
        {

            Flip();
        }
        else if(right == true && moveInput < 0)
        {

            Flip();
        }
    }

    void Update()
    {

        if(grounded == true)
        {

            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {

            rb.velocity = Vector2.up * jump;
            extraJumps --;
        }else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && grounded == true)
        {

            rb.velocity = Vector2.up * jump;
        }
    }

    void Flip()
    {
        
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
*/