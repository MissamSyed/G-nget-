using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public bool _playerCanMove = true;
    public bool _isTouchingCloset = false;
    public bool _playerIsHiding = false;

    public GameObject _chosenCloset;

    [SerializeField] SpriteRenderer _playerSprite;

    void Start()
    {
        
    }
    public bool CanMove()
    {
        return _playerCanMove;
    }

    void PartsInvisible(Transform doorTransform, bool value)
    {
        _playerSprite.enabled = value;
        doorTransform.gameObject.SetActive(value);
    }

    void OnInteract()
    {
        if (_isTouchingCloset)
        {
            Transform doorTransform = _chosenCloset.transform.Find("Door");
            if (_playerIsHiding == false)
            {
                Debug.Log("Player is hiding!");

                PartsInvisible(doorTransform, false);

                _playerIsHiding = true;
                _playerCanMove = false;
            }
            else
            {
                Debug.Log("Player is exposed!");

                PartsInvisible(doorTransform, true);

                _playerIsHiding = false;
                _playerCanMove = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Closet"))
        {
            Debug.Log("Closet touched!");
            _chosenCloset = collision.gameObject;
            _isTouchingCloset = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Closet"))
        {
            Debug.Log("Closet left!");
            
            _chosenCloset = null;
            _isTouchingCloset = false;
            _playerIsHiding = false;
        }
    }

}
