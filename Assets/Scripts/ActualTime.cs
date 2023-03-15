using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActualTime : MonoBehaviour
{
    public string time = "";
    public string spawnHour = "";
    public GameObject testObject;


    void Update()
    {
    
        time = DateTime.Now.ToString();
        string hour = time[11].ToString() + time[12].ToString();
        
        if(hour == spawnHour)
        {

            testObject.SetActive(true);
        }else
        {
            
            testObject.SetActive(false);
        }
    }
}