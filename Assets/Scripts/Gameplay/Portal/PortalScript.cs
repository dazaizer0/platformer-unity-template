using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    
    private GameObject player;

    public bool portal_entered = false;
    public bool to_portal_two = true;
    public bool to_portal_one = true;
    public bool one_way;

    [Header("transform")]
    public Transform portal_one;
    public Transform portal_two;


    void Start()
    {

        player = GameObject.Find("Joe");
    }

    void Update()
    {

        to_portal_two = true;
        
        if(portal_entered && to_portal_two)
        {

            player.transform.position = portal_two.position;

            to_portal_two = false;
            portal_entered = false;
        }
    }
}
