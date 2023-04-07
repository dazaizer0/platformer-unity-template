using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParafalxBackGround : MonoBehaviour
{
    private float lenght, startpos;
    public GameObject cam;
    public float paralaxeffext;

    void Start()
    {
        startpos  =transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance  =(cam.transform.position.x * paralaxeffext);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
