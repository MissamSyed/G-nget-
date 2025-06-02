using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabObject : MonoBehaviour
{
    [SerializeField] GameObject _textLabelObject;

    public GameObject _timeController;
    public GameObject _newTimeController;
    public GameObject _keyObject;

    public bool _hasExitKey = false;

    private bool _isTouchingKey = false;
    private TextMeshProUGUI _textLabel;
    private GameTimer _timeControllerScript;

    private void Start()
    {
        _textLabel = _textLabelObject.GetComponent<TextMeshProUGUI>();
        _timeControllerScript = _timeController.GetComponent<GameTimer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            Debug.Log("Touched key");
            _isTouchingKey = true;

            _keyObject = collision.gameObject;
        } 
        else if (collision.CompareTag("Exit") && _hasExitKey)
        {
            Debug.Log("You win!");
            _textLabelObject.SetActive(false);
            SceneManager.LoadScene(3);

            //if (_newTimeController)
            //{
            //    TextMeshProUGUI newTextMesh = _newTimeController.GetComponent<TextMeshProUGUI>();
            //    newTextMesh.text = _timeControllerScript.GetTimeInText();
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            _isTouchingKey = false;
            _keyObject = null;
        }
    }

    private void Update()
    {
        if (_isTouchingKey && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pressed F while touching key!");
            _hasExitKey = true;
            
            if (_keyObject != null)
            {
                _keyObject.SetActive(false);
                _textLabel.text = "Objective: Find the exit";
            }

        }
    }
}
