using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    int i;
    public int[] attack = new int[3];
    public int num;
    public int sign;
    public int result;
    int first;

    public GameObject NumScollview; //숫자
    public GameObject CalculScollview; //연산기호

    public void re ()
    {
        i = 0;
        sign = 0;
        result = 0;
        first = 1;
        num = -1;
    }

    void Start ()
    {
        num = -1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            re();
            ScrollChange2();
        }
    }

    public void calculator ()
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

    public void ScrollChange1()
    {
        NumScollview.SetActive(false);
        CalculScollview.SetActive(true);
    }
    public void ScrollChange2()
    {
        NumScollview.SetActive(true);
        CalculScollview.SetActive(false);
    }
}