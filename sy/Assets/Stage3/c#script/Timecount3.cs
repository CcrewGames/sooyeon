using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timecount3 : MonoBehaviour
{
    public float countdownSeconds;
    private TextMeshProUGUI timeText;

    private bool timeend;

    public GameObject numbun;

    private void Start()
    {
        countdownSeconds = 60;
        timeText = GetComponent<TextMeshProUGUI>();
        timeend = true;
    }

    void Update()
    {
        if(numbun.GetComponent<NumberBundleScript>().fortime == 1)
            countdownSeconds -= Time.deltaTime;

        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
        if (timeend == true){
            if (countdownSeconds <= 0) //시간 초과 fail
            {
                //Invoke("End", 1f);
                timeend = false;
            }
        }
    }
    void End()
    {
        //졌으면 Fail, 이겼으면 스토리로 넘어가기
    }
}