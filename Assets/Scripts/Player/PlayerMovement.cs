using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 screenBoundary;
    Vector2 moveInput;
    Rigidbody2D rb;

    PlayerHide playerHide;

    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHide = GetComponent<PlayerHide>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        bool canWalk = playerHide.CanMove();

        if (canWalk)
        {
            rb.velocity = moveInput * moveSpeed;

            if (moveInput != Vector2.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
                Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                rb.MoveRotation(rotate);
            }
            else
            {
                rb.angularVelocity = 0;
            }

            screenBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundary.x, screenBoundary.x), Mathf.Clamp(transform.position.y, -screenBoundary.y, screenBoundary.y));
        }
    }
}
