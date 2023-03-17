using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool enter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && enter == true)
        {

            //rb.bodyType = RigidbodyType2D.Dynamic;
            //rb.gravityScale = 1.1f;
            Destroy(gameObject, 0.5f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player" && enter == false)
        {

            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1.1f;
            Destroy(gameObject, 0.7f);
        }
    }
}
