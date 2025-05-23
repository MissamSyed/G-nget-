using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform currentWeapon;
    public bool hasGun = false;
    public Transform hand;
    public PlayerPickupShotgun playerPickupShotgun;

    void Start()
    {
        currentWeapon = hand;
    }

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Pickup") && !hasGun && !playerPickupShotgun.hasShotgun)
        {
            Debug.Log("Press E to pick up");
            other.transform.SetParent(currentWeapon);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;

            hasGun = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}