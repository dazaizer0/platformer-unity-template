using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{

    public PortalScript portal_script;
    public bool is_one;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && is_one)
        {
            
            portal_script.portal_entered = true;
        }
    }
}
