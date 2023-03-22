using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    
    private GameObject player;
    public bool portal_entered = false;


    [Header("transform")]
    public Transform portal_two;


    void Start()
    {

        player = GameObject.Find("Joe");
    }

    void Update()
    {

        if(portal_entered)
        {

            player.transform.position = portal_two.position;
            portal_entered = false;
        }
    }
}
