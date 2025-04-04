using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject PlayerGun;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnFire()
    {
        GameObject bullet = Instantiate(playerBullet, PlayerGun.transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            OnFire();
        }
    }
}