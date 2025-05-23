using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject PlayerGun;
    public PlayerPickup playerPickup;
    // Start is called before the first frame update

    void Start()
    {
        playerPickup = FindFirstObjectByType<PlayerPickup>();
    }

    void OnFire()
    {
        if (playerPickup.hasGun == true)
        {
            GameObject bullet = Instantiate(playerBullet, PlayerGun.transform.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}