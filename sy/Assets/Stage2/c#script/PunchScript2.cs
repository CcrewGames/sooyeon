using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript2 : MonoBehaviour
{
    public int punchmode; //0은 None, 1은 Attack, 2는 Healing
    public GameObject AttackBar; //공격바
    public GameObject HealingBar; //힐링바

    public GameObject NumScollview; //숫자
    public GameObject CalculScollview; //연산기호
    public GameObject C;

    public int[] attack = new int[3];
    public int i;
    public int num;
    public int sign;
    public int result;

    public GameObject numberbar;

    public int random;

    void Start() //게임 시작 초기화
    {
        i = 1;
        sign = 0;
        result = 0;
        num = -1;
        off();
    }

    public void off() //계산 초기화 함수
    {
        i = 0;
        sign = 0;
        result = 0;
        num = 0;
        random = 0;
        numberbar.GetComponent<NumberBarScript2>().off();
    }

    public void re() //계산 초기화 함수
    {
        Debug.Log("버튼");
        i = 1;
        sign = 0;
        result = 0;
        num = -1;
        random = Random.Range(15, 30);
        attack[0] = random;

        numberbar.GetComponent<NumberBarScript2>().re();
    }

    public void calculator() //계산 함수
    {
        if (i == 1) //두번째 연산기호
        {
            attack[i] = sign;
            i++;
            ScrollChange1();
            numberbar.GetComponent<NumberBarScript2>().nummaker();
        }
        else if (i == 2) //세번째 숫자
        {
            attack[i] = num;
            ScrollChange2();
            if (attack[1] == 1)
            {
                result = attack[0] + attack[2];
            }
            else if (attack[1] == 2)
            {
                if (attack[0] < attack[2])
                {
                    result = 0;
                    Debug.Log("0보다 작은 수를 만들 수 없습니다.");
                }
                else
                {
                    result = attack[0] - attack[2];
                }
            }
            else if (attack[1] == 3)
            {
                result = attack[0] * attack[2];
            }
            else if (attack[1] == 4)
            {
                if (attack[0] % attack[2] != 0)
                {
                    result = attack[0];
                    Debug.Log("약수로만 나눌 수 있습니다.");
                }
                else
                {
                    result = attack[0] / attack[2];
                }
            }

            if(result > 999)
            {
                result = 999;
                Debug.Log("999보다 큰 수를 만들 수 없습니다.");
            }

            attack[0] = result;
            i = 1;

            numberbar.GetComponent<NumberBarScript2>().nummaker();
        }
    }

    public void ScrollChange2() //연산기호만
    {
        NumScollview.SetActive(false);
        CalculScollview.SetActive(true);
        C.SetActive(true);
    }
    public void ScrollChange1() //숫자만
    {
        NumScollview.SetActive(true);
        CalculScollview.SetActive(false);
        C.SetActive(true);
    }
    public void ScrollChange3() //다 Off
    {
        NumScollview.SetActive(false);
        CalculScollview.SetActive(false);
        C.SetActive(false);
    }

    public void PunchMode()
    {
        if (punchmode == 1) //힐모드
        {
            HealingBar.SetActive(false);
            AttackBar.SetActive(true);
        }
        else if (punchmode == 2) //어택모드
        {
            AttackBar.SetActive(false);
            HealingBar.SetActive(true);
        }
        else if (punchmode == 0) //다 Off
        {
            AttackBar.SetActive(false);
            HealingBar.SetActive(false);
        }
    }
}