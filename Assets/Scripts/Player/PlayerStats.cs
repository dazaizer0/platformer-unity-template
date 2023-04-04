using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

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
}
