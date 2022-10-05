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

    int first;

    public GameObject NumScollview; //숫자
    public GameObject CalculScollview; //연산기호

    public void re () //계산 초기화 함수
    {
        i = 0;
        sign = 0;
        result = 0;
        first = 1;
        num = -1;
    }

    void Start () //게임 시작 초기화
    {
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
        if(i == 0)
        {
            attack[i] = num;
            i++;
            result = num;
            ScrollChange1();
        }
        else if(i == 1)
        {
            attack[i] = sign;
            i++;
            ScrollChange2();
        }
        else if(i == 2)
        {
            attack[i] = num;
            ScrollChange1();
            if (attack[1] == 1 && first == 1)
            {
                result = attack[0] + attack[2];
                first = 0;
            }
            else if (attack[1] == 2 && first == 1)
            {
                result = attack[0] - attack[2];
                first = 0;
            }
            else if (attack[1] == 3 && first == 1)
            {
                result = attack[0] * attack[2];
                first = 0;
            }
            else if (attack[1] == 4 && first == 1)
            {
                result = attack[0] / attack[2];
                first = 0;
            }
            else if (attack[1] == 1 && first == 0)
            {
                result += attack[2];
            }
            else if (attack[1] == 2 && first == 0)
            {
                result -= attack[2];
            }
            else if (attack[1] == 3 && first == 0)
            {
                result *= attack[2];
            }
            else if (attack[1] == 4 && first == 0)
            {
                result /= attack[2];
            }
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