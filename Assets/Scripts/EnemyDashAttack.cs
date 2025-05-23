using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashAttack : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 6f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.4f;

    private Rigidbody2D rb;
    private bool hasDashed = false;
    private bool isDashing = false;
    private float dashTime = 0f;
    private Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (!hasDashed && distance <= detectionRange)
        {
            dashDirection = (player.position - transform.position).normalized;
            StartDash();
        }

        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                StopDash();
            }
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed;
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        hasDashed = true;
        
    }

    void StopDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero;
        
    }

    
    public void ResetDash()
    {
        hasDashed = false;
    }
}
