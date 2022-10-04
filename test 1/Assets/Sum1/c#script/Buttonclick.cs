using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonclick : MonoBehaviour
{
    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13; //버튼

    public GameObject punch; //계산

    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;
    public GameObject num8;
    public GameObject num9;

    public GameObject sign1;
    public GameObject sign2;
    public GameObject sign3;
    public GameObject sign4;

    //날려보내는 함수
    public IEnumerator flying(GameObject NumberImage){
        Debug.Log(NumberImage);
        Vector3 destination = new Vector3(-5.86f, 2.34f, -1.06f); //날려보내기
        while(transform.position != destination)
        {
            //Vector3 speed = Vector3.zero; 
            NumberImage.transform.position = Vector3.Lerp(NumberImage.transform.position, destination, 0.04f);        
            yield return null;
        }
    }

    void Start() //클릭하면
    {
        btn1.onClick.AddListener(() => btnprint(num1));
        btn2.onClick.AddListener(() => btnprint(num2));
        btn3.onClick.AddListener(() => btnprint(num3));
        btn4.onClick.AddListener(() => btnprint(num4));
        btn5.onClick.AddListener(() => btnprint(num5));
        btn6.onClick.AddListener(() => btnprint(num6));
        btn7.onClick.AddListener(() => btnprint(num7));
        btn8.onClick.AddListener(() => btnprint(num8));
        btn9.onClick.AddListener(() => btnprint(num9));
        btn10.onClick.AddListener(() => btnprint(sign1));
        btn11.onClick.AddListener(() => btnprint(sign2));
        btn12.onClick.AddListener(() => btnprint(sign3));
        btn13.onClick.AddListener(() => btnprint(sign4));
    }

    // 1번
    void btnprint(GameObject Num)
    {
        if (Num == num1)
        {
            punch.GetComponent<PunchScript>().num = 1;
        }
        else if (Num == num2)
        {
            punch.GetComponent<PunchScript>().num = 2;
        }
        else if (Num == num3)
        {
            punch.GetComponent<PunchScript>().num = 3;
        }
        else if (Num == num4)
        {
            punch.GetComponent<PunchScript>().num = 4;
        }
        else if (Num == num5)
        {
            punch.GetComponent<PunchScript>().num = 5;
        }
        else if (Num == num6)
        {
            punch.GetComponent<PunchScript>().num = 6;
        }
        else if (Num == num7)
        {
            punch.GetComponent<PunchScript>().num = 7;
        }
        else if (Num == num8)
        {
            punch.GetComponent<PunchScript>().num = 8;
        }
        else if (Num == num9)
        {
            punch.GetComponent<PunchScript>().num = 9;
        }
        else if (Num == sign1)
        {
            punch.GetComponent<PunchScript>().sign = 1;
        }
        else if (Num == sign2)
        {
            punch.GetComponent<PunchScript>().sign = 2;
        }
        else if (Num == sign3)
        {
            punch.GetComponent<PunchScript>().sign = 3;
        }
        else if (Num == sign4)
        {
            punch.GetComponent<PunchScript>().sign = 4;
        }
        punch.GetComponent<PunchScript>().calculator();
    }
}
