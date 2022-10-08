using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    public int[] attack = new int[3];
    int i;

    public int num;
    public int sign;
    public int result;

    public GameObject numberbar;

    public GameObject NumScollview; //숫자
    public GameObject CalculScollview; //연산기호

    public void re () //계산 초기화 함수
    {
        i = 0;
        sign = 0;
        result = 0;
        num = -1;

        numberbar.GetComponent<NumberBarScript>().re();
    }

    void Start () //게임 시작 초기화
    {
        i = 0;
        sign = 0;
        result = 0;
        num = -1;
    }

    void Update() //계산 초기화 실행 함수
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            re();
            ScrollChange2();
        }
    }

    public void calculator () //계산 함수
    {
        if(i == 0) //첫번째 숫자
        {
            attack[i] = num;
            i++;
            result = num;
            ScrollChange1();
            numberbar.GetComponent<NumberBarScript>().nummaker();
        }
        else if(i == 1) //두번째 연산기호
        {
            attack[i] = sign;
            i++;
            ScrollChange2();
            numberbar.GetComponent<NumberBarScript>().nummaker();
        }
        else if(i == 2) //세번째 숫자
        {
            attack[i] = num;
            ScrollChange1();
            numberbar.GetComponent<NumberBarScript>().nummaker();
            if (attack[1] == 1)
            {
                result = attack[0] + attack[2];
            }
            else if (attack[1] == 2)
            {
                result = attack[0] - attack[2];
            }
            else if (attack[1] == 3)
            {
                result = attack[0] * attack[2];
            }
            else if (attack[1] == 4)
            {
                result = attack[0] / attack[2];
            }
            attack[0] = result;
            i = 1;
        }
    }

    public void ScrollChange1() //연산기호만
    {
        NumScollview.SetActive(false);
        CalculScollview.SetActive(true);
    }
    public void ScrollChange2() //숫자만
    {
        NumScollview.SetActive(true);
        CalculScollview.SetActive(false);
    }
}