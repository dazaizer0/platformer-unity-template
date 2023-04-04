using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnObjectAtHour : MonoBehaviour
{

    public string spawnHour = "";
    public GameObject testObject;


    void Update()
    {
        
        if(TimeManager.hour == spawnHour)
        {

            testObject.SetActive(true);
        }else
        {
            
            testObject.SetActive(false);
        }
    }
}