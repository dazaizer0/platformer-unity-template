using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public Transform spawn_point;
    public TextMeshProUGUI ScoreText;
    public float score;

    void Start()
    {
        
        score = 500f;
    }

    void Update()
    {
        
        score -= 1 * Time.deltaTime;
    }

    void FixedUpdate()
    {

        IntToTxt(ScoreText, score);
    }

    public void IntToTxt(TextMeshProUGUI ScoreText, float score)
    {

        ScoreText.text = score.ToString("F1");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "damage_object")
        {

            score -= 50f;
            transform.position = spawn_point.position;
        }
    }
}
