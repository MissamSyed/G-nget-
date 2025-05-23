using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickupShotgun : MonoBehaviour
{
    public Transform currentWeapon;
    public bool hasShotgun = false;
    public Transform hand;
    public PlayerPickup playerPickup;

    void Start()
    {
        currentWeapon = hand;
    }

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("PickupShotgun") && !hasShotgun && !playerPickup.hasGun)
        {
            Debug.Log("Press E to pick up");
            other.transform.SetParent(currentWeapon);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;

            hasShotgun = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}