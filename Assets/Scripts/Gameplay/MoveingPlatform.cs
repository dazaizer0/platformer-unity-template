using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{

    public Transform lpoint, rpoint, platform;
    public float speed = 2f;
    public Vector2 destination;

    void Start() {destination = rpoint.position;}

    void Update()
    {

        if (Vector2.Distance(transform.position, rpoint.position) < .1f)
        {

            destination = lpoint.position;
        }

        if (Vector2.Distance(transform.position, lpoint.position) < .1f)
        {

            destination = rpoint.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {other.transform.SetParent(platform);}
    void OnTriggerExit2D(Collider2D other) {other.transform.SetParent(null);}
}
