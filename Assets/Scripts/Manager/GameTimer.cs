using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerLabel;

    private float elapsedTime = 0f;

    private void Start()
    {
        // Reset timer when scene starts
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timerLabel.text = $"{minutes}:{seconds:D2}"; // D2 pads single digits with a 0
    }

    public string GetTimeInText()
    {
        return timerLabel.text.ToString();
    }
}
