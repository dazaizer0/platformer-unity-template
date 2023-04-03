using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScene : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {

            SceneManager.LoadScene(0);
        }
    }
}
