using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    private bool isTouchingCloset = false;
    private GameObject chosenCloset;

    void Start()
    {

    }

    void HideInCloset()
    {

    }
    void OnInteract()
    {
        if (isTouchingCloset)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Closet"))
        {
            Debug.Log("Closet touched!");
            chosenCloset = collision.gameObject;
            isTouchingCloset = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Closet"))
        {
            Debug.Log("Closet left!");
            chosenCloset = null;
            isTouchingCloset = false;
        }
    }

}
