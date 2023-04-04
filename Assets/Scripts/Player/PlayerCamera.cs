using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    
    public Transform target;
    public float smoothTime = 0.3f;

    public Vector3 offset;
    private Vector3 velocity;

    private void LateUpdate()
    {

        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
    }
}
