using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponShootingShotgun : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject PlayerGun;
    public PlayerPickupShotgun playerPickupShotgun;
    // Start is called before the first frame update

    void Start()
    {
        playerPickupShotgun = FindFirstObjectByType<PlayerPickupShotgun>();
    }

    void OnFire()
    {
        if (playerPickupShotgun.hasShotgun == true)
        {
            float spreadAngle = 15f;
            for (int i = -1; i <= 1; i++)
            {
                Quaternion spread = Quaternion.Euler(0, 0, transform.eulerAngles.z + (i * spreadAngle));
                GameObject bullet = Instantiate(playerBullet, PlayerGun.transform.position, spread);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(spread * Vector2.up * playerBulletSpeed, ForceMode2D.Impulse);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}