using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public DarkPeriods darkPeriodsScript;
    public PlayerHide playerHideScript;

    private void Awake()
    {
        if (darkPeriodsScript == null)
        {
            darkPeriodsScript = FindObjectOfType<DarkPeriods>();
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (darkPeriodsScript.GetDarkMode())
        {
            if (playerHideScript.PlayerIsHiding() == false)
            {
                PlayerDie(0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDie(2);
        }
    }

    void PlayerDie(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        
    }
}
