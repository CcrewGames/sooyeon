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

    private bool timeend;

    public GameObject stage;

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timeend = true;
    }

    void Update()
    {
        if(stage.GetComponent<Stage>().fortime == 1)
            countdownSeconds -= Time.deltaTime;

        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
        if (timeend == true){
            if (countdownSeconds <= 0) //시간 초과 fail
            {
                Invoke("Stagetimeout", 1f);
                Invoke("end", 5f);
                Debug.Log("failed");
                timeend = false;
            }
        }
    }
    void Stagetimeout()
    {
        var ending = GameObject.Find("ending").GetComponent<endingscene>();
        if(ending != null)
        {
            ending.Stagetimeout();
        }
    }

    void end()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}