using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timecount : MonoBehaviour
{

    public float countdownSeconds = 210;
    private TextMeshProUGUI timeText;

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

        if (countdownSeconds <= 0)
        {
            //여기에 fail
            Debug.Log("failed");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}