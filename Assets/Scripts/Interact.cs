using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool isInteractable = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        isInteractable = true;
        Debug.Log("interaction PROMPT");
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isInteractable = false;
    }
    void Update()
    {
        if(isInteractable == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("INTERACTION");
        }
    }

    //down here are methods/functions that define diferent ways to interact; e.g., disappears after use, have to hit 'e' multiple times, etc.
}
