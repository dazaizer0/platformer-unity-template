using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{

    // public
    [Header("Actual Time")]
    public string Time;
    public TextMeshProUGUI TimeText;

    // other
    public static string hour;
    public static string minute;
    public static string seckond;

    // TIME
    public static string time = "";

    void Update()
    {

        time = DateTime.Now.ToString("HH:mm:ss tt");;

        Time = time;
        ToText(TimeText, Time);

        hour = TimeManager.time[0].ToString() + TimeManager.time[1].ToString();
        minute = TimeManager.time[3].ToString() + TimeManager.time[4].ToString();
        seckond = TimeManager.time[6].ToString() + TimeManager.time[7].ToString();
    }

    public TextMeshProUGUI ToText(TextMeshProUGUI text, string time)
    {

        text.text = time;
        return text;
    } 
}
