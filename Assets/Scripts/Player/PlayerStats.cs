using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public Transform spawn_point;

    public TextMeshProUGUI ScoreText;
    public static float score;

    public TextMeshProUGUI DashCooldownText;

    private string active_scene;


    void Start()
    {
        
        score = 180f;
        active_scene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        
        score -= 1 * Time.deltaTime;
        if(score <= 0) {SceneManager.LoadScene(active_scene);}
        IntToTxt(DashCooldownText, PlayerMovement.dashForwardCooldown);
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

            score -= 49f;
            transform.position = spawn_point.position;
        }
    }
}
