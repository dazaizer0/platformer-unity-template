using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [Header("parametry")]

    public Transform target;
    public float smoothTime = 0.3f;

    public Vector3 offset;
    private Vector3 velocity;

    [Header("obszar")]

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public bool MaxAndMinSet = false;

    void Update()
    {
        if(MaxAndMinSet)
        {

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), 
                Mathf.Clamp(transform.position.y, yMin, yMax), 
                transform.position.z);
        }
    }
    
    private void LateUpdate()
    {
        
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
    }
}
