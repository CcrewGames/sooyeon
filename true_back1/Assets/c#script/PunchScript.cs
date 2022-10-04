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
    public int pun;
    int first;

    public void re ()
    {
        Debug.Log(result);
        pun = result;

        i = 0;
        sign = 0;
        result = 0;
        first = 1;
        num = -1;
    }

    public void calculator ()
    {
        if(i == 0)
        {
            if (num != -1)
            { 
                attack[i] = num;
                i++;
                result = num;
            }
            else
            {
                Debug.Log("숫자를 입력하시오.");
            }
        }
        else if(i == 1)
        {
            if (num != -1)
            {
                Debug.Log("연산 기호를 입력하시오.");
            }
            else
            {
                attack[i] = sign;
                i++;
            }
        }
        else if(i == 2)
        {
            if (num != -1)
            {
                attack[i] = num;
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
                else if(attack[1] == 3 && first == 1)
                {
                    result = attack[0] * attack[2];
                    first = 0;
                }
                else if(attack[1] == 4 && first == 1)
                {
                    result = attack[0] / attack[2];
                    first = 0;
                }
                else if(attack[1] == 1 && first == 0)
                {
                    result += attack[2];
                }
                else if(attack[1] == 2 && first == 0)
                {
                    result -= attack[2];
                }
                else if(attack[1] == 3 && first == 0)
                {
                    result *= attack[2];
                }
                else if(attack[1] == 4 && first == 0)
                {
                    result /= attack[2];
                }
                i = 1;
            }
            else
            {
                Debug.Log("숫자를 입력하시오.");
            }
        }
    }
}
