using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{

    public int number_of_scene;
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {

            SceneManager.LoadScene(number_of_scene);
        }
    }
}
