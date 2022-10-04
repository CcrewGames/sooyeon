using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonclick : MonoBehaviour
{
    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0;
    public GameObject punch;

    [SerializeField]
    private GameObject num1;
    [SerializeField]
    private GameObject num2;
    [SerializeField]
    private GameObject num3;
    [SerializeField]
    private GameObject num4;
    [SerializeField]
    private GameObject num5;
    [SerializeField]
    private GameObject num6;
    [SerializeField]
    private GameObject num7;
    [SerializeField]
    private GameObject num8;
    [SerializeField]
    private GameObject num9;
    [SerializeField]
    private GameObject num0;

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

    void Start() // 클릭하면
    {
        btn1.onClick.AddListener(btn1print);
        btn2.onClick.AddListener(btn2print);
        btn3.onClick.AddListener(btn3print);
        btn4.onClick.AddListener(btn4print);
        btn5.onClick.AddListener(btn5print);
        btn6.onClick.AddListener(btn6print);
        btn7.onClick.AddListener(btn7print);
        btn8.onClick.AddListener(btn8print);
        btn9.onClick.AddListener(btn9print);
        btn0.onClick.AddListener(btn0print);
    }

    void btn1print()
    {
        Debug.Log("1"); // 콘솔에 넘버 찍고
        GameObject number0 = Instantiate(num1, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number0));//날아감
        punch.GetComponent<PunchScript>().num = 1;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn2print()
    {
        Debug.Log("2"); // 콘솔에 넘버 찍고
        GameObject number2 = Instantiate(num2, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number2));//날아감
        punch.GetComponent<PunchScript>().num = 2;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn3print()
    {
        Debug.Log("3"); // 콘솔에 넘버 찍고
        GameObject number3 = Instantiate(num3, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number3));//날아감
        punch.GetComponent<PunchScript>().num = 3;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn4print()
    {
        Debug.Log("4"); // 콘솔에 넘버 찍고
        GameObject number4 = Instantiate(num4, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number4));//날아감
        punch.GetComponent<PunchScript>().num = 4;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn5print()
    {
        Debug.Log("5"); // 콘솔에 넘버 찍고
        GameObject number5 = Instantiate(num5, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number5));//날아감
        punch.GetComponent<PunchScript>().num = 5;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn6print()
    {
        Debug.Log("6"); // 콘솔에 넘버 찍고
        GameObject number6 = Instantiate(num6, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number6));//날아감
        punch.GetComponent<PunchScript>().num = 6;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn7print()
    {
        Debug.Log("7"); // 콘솔에 넘버 찍고
        GameObject number7 = Instantiate(num7, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number7));//날아감
        punch.GetComponent<PunchScript>().num = 7;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn8print()
    {
        Debug.Log("8"); // 콘솔에 넘버 찍고
        GameObject number8 = Instantiate(num8, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number8));//날아감
        punch.GetComponent<PunchScript>().num = 8;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn9print()
    {
        Debug.Log("+"); // 콘솔에 넘버 찍고
        GameObject number9 = Instantiate(num9, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number9));//날아감
        punch.GetComponent<PunchScript>().sign = 1;
        punch.GetComponent<PunchScript>().num = -1;
        punch.GetComponent<PunchScript>().calculator();
    }
    void btn0print()
    {
        Debug.Log("-"); // 콘솔에 넘버 찍고
        GameObject number0 = Instantiate(num0, new Vector3(-3.08f,-3.67f,0), Quaternion.identity); // 숫자이미지생성하고
        StartCoroutine(flying(number0));//날아감
        punch.GetComponent<PunchScript>().sign = 2;
        punch.GetComponent<PunchScript>().num = -1;
        punch.GetComponent<PunchScript>().calculator();
    }
}
