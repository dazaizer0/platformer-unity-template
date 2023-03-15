using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public GameObject ObjectToSet;

    void Start()
    {

        ObjectToSet.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "PuzzleUnlockObject")
        {

            ObjectToSet.SetActive(true);
        }
    }
}
