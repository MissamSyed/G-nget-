using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloak : MonoBehaviour
{
    public Transform player;            
    public float detectionRadius = 5f;  
    public float uncloakDelay = 5f;     

    private SpriteRenderer spriteRenderer;
    private bool isCloaked = false;
    private float uncloakTimer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (player == null)
        {
            Debug.LogWarning("Player not assigned in EnemyCloak script!");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            
            Cloak();
            uncloakTimer = 0f; 
        }
        else
        {
            
            if (isCloaked)
            {
                uncloakTimer += Time.deltaTime;
                if (uncloakTimer >= uncloakDelay)
                {
                    Uncloak();
                }
            }
        }
    }

    void Cloak()
    {
        if (!isCloaked)
        {
            spriteRenderer.enabled = false; 
            isCloaked = true;
            
        }
    }

    void Uncloak()
    {
        if (isCloaked)
        {
            spriteRenderer.enabled = true;
            isCloaked = false;
            
        }
    }
}
