using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{

    public static string hour;
    public static string minute;
    public static string seckond;

    // TIME
    public static string time = "";

    void Update()
    {

        time = DateTime.Now.ToString("HH:mm:ss tt");;

        hour = TimeManager.time[0].ToString() + TimeManager.time[1].ToString();
        minute = TimeManager.time[3].ToString() + TimeManager.time[4].ToString();
        seckond = TimeManager.time[6].ToString() + TimeManager.time[7].ToString();
    }
}
