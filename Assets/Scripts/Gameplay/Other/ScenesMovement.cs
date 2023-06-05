using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesMovement : MonoBehaviour
{

    public string SceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            SceneManager.LoadScene(SceneName);
        }
    }
}
