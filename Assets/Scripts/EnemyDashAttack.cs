using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashAttack : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 6f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.4f;
    public float dashCooldown = 2f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isDashing = false;

    private float dashTime = 0f;
    private float cooldownTimer = 0f;
    private Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (!isDashing && cooldownTimer <= 0 && distance <= detectionRange)
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
        cooldownTimer = dashCooldown;

        
        spriteRenderer.enabled = false;
    }

    void StopDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero;

        
        spriteRenderer.enabled = true;
    }
}
