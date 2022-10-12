using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBarScript : MonoBehaviour
{
    public GameObject punch;

    public GameObject number;
    private GameObject num1; //���� �ڸ�
    private GameObject num2; //���� �ڸ�
    private GameObject num3; //���� �ڸ�
    private GameObject sign;
    private GameObject endnum;
    
    int i;
    int j;
    bool move1; //����� ������
    bool move2; //�������� ������
    bool move3; //���ƿ��� �ϱ�

    float speed = 3f;
    float dis = 0.25f; //���� ����

    float time = 0.2f;
    float time1 = 0.2f;

    float height = 2.5f;

    Vector2 MousePosition;

    Camera Camera;

    void Start()
    {
        num1 = Instantiate(number, new Vector3(0, 0, -1), transform.rotation);
        num2 = Instantiate(number, new Vector3(0, 0, -1), transform.rotation);
        num3 = Instantiate(number, new Vector3(0, 0, -1), transform.rotation);
        sign = Instantiate(number, new Vector3(0, 0, -1), transform.rotation);
        endnum = Instantiate(number, new Vector3(0, 0, -1), transform.rotation);

        re();

        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void re()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        sign.SetActive(false);
        endnum.SetActive(false);

        i = 0;
        j = 0;

        move1 = false;
        move2 = false;
    }

    void Update()
    {
        if (move1 == true)
            Run1();

        if (move2 == true)
            Run2();

        if (move3 == true)
            Run3();

        if(Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);
        }

        num2.transform.position = new Vector3(num1.transform.position.x - 2 * dis, num1.transform.position.y, -1);
        num3.transform.position = new Vector3(num1.transform.position.x - 4 * dis, num1.transform.position.y, -1);
    }

    public void nummaker()
    {
        Sprite[] spritesN = Resources.LoadAll<Sprite>("number");
        Sprite[] spritesM = Resources.LoadAll<Sprite>("sign");
        if (i == 0)
        {
            num1.transform.position = new Vector3(MousePosition.x, MousePosition.y, -1);
            move3 = true;
            Invoke("Stop3", time1);

            num1.SetActive(true);
            SpriteRenderer spriteJ = num1.GetComponent<SpriteRenderer>();
            spriteJ.sprite = spritesN[punch.GetComponent<PunchScript>().attack[0]];

            i++;
        }
        else if (i == 1)
        {
            move2 = true;
            Invoke("Stop2", time);

            sign.transform.position = new Vector3(MousePosition.x, MousePosition.y, -1);
            move3 = true;
            Invoke("Stop3", time1);

            sign.SetActive(true);
            SpriteRenderer spriteK = sign.GetComponent<SpriteRenderer>();
            spriteK.sprite = spritesM[punch.GetComponent<PunchScript>().attack[1] - 1];

            i++;
        }
        else if (i == 2)
        {
            endnum.transform.position = new Vector3(MousePosition.x, MousePosition.y, -1);
            move3 = true;
            Invoke("Stop3", time1);
            Invoke("Joff", time1);

            endnum.SetActive(true);
            SpriteRenderer spriteL = endnum.GetComponent<SpriteRenderer>();
            spriteL.sprite = spritesN[punch.GetComponent<PunchScript>().attack[2]];

            Invoke("Run1Start", time);
            Invoke("Stop1", time + time1);
            i = 1;
        }
    }

    void Run1Start()
    {
        move1 = true;
    }
    void Run1() //����� ������
    {
        if (punch.GetComponent<PunchScript>().result > 99 && punch.GetComponent<PunchScript>().result <= 999)
        {
            num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-5 + 2 * dis, height, -1), Time.deltaTime * speed);
        }
        else if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-5 + dis, height, -1), Time.deltaTime * speed);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-5, height, -1), Time.deltaTime * speed);
        }
        endnum.transform.position = Vector3.Lerp(endnum.transform.position, new Vector3(-5, height, -1), Time.deltaTime * speed);
    }
    void Stop1()
    {
        if (punch.GetComponent<PunchScript>().result > 99 && punch.GetComponent<PunchScript>().result <= 999)
        {
            num1.transform.position = new Vector3(-5 + 2 * dis, height, -1);
        }
        else if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = new Vector3(-5 + dis, height, -1);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num1.transform.position = new Vector3(-5, height, -1);
        }
        endnum.transform.position = new Vector3(-5, height, -1);

        move1 = false;
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        sign.SetActive(false);
        endnum.SetActive(false);

        Sprite[] spritesN = Resources.LoadAll<Sprite>("number");
        Sprite[] spritesM = Resources.LoadAll<Sprite>("sign");

        int a = punch.GetComponent<PunchScript>().result % 10; //���� �ڸ�
        int b = (punch.GetComponent<PunchScript>().result / 10) % 10; //���� �ڸ�
        int c = punch.GetComponent<PunchScript>().result / 100; //���� �ڸ�

        SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
        spriteA.sprite = spritesN[a];
        SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
        spriteB.sprite = spritesN[b];
        SpriteRenderer spriteC = num3.GetComponent<SpriteRenderer>();
        spriteC.sprite = spritesN[c];

        if (punch.GetComponent<PunchScript>().result > 99 && punch.GetComponent<PunchScript>().result <= 999)
        {
            num1.SetActive(true);
            num2.SetActive(true);
            num3.SetActive(true);
        }
        else if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.SetActive(true);
            num2.SetActive(true);
            num3.SetActive(false);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num1.SetActive(true);
            num2.SetActive(false);
            num3.SetActive(false);
        }
    }

    void Run2() //�������� ������
    {
        if (punch.GetComponent<PunchScript>().result > 99 && punch.GetComponent<PunchScript>().result <= 999)
        {
            num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-6 + 2 * dis, height, -1), Time.deltaTime * speed);
        }
        else if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-6 + dis, height, -1), Time.deltaTime * speed);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-6, height, -1), Time.deltaTime * speed);
        }
    }
    void Stop2()
    {
        if (punch.GetComponent<PunchScript>().result > 99 && punch.GetComponent<PunchScript>().result <= 999)
        {
            num1.transform.position = new Vector3(-6 + 2 * dis, height, -1);
        }
        else if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = new Vector3(-6 + dis, height, -1);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num1.transform.position = new Vector3(-6, height, -1);
        }
        move2 = false;
    }

    void Run3() //���ư��� �ϱ�
    {
        if (j == 0)
        {
            num1.transform.position = Vector3.Slerp(num1.transform.position, new Vector3(-5, height, -1), Time.deltaTime * 8);
        }
        else if (j == 1)
        {
            sign.transform.position = Vector3.Slerp(sign.transform.position, new Vector3(-5, height, -1), Time.deltaTime * 8);
        }
        else if (j == 2)
        {
            endnum.transform.position = Vector3.Slerp(endnum.transform.position, new Vector3(-4, height, -1), Time.deltaTime * 8);
        }
    }
    void Stop3()
    {
        if (j == 0)
        {
            num1.transform.position = new Vector3(-5, height, -1);
        }
        else if (j == 1)
        {
            sign.transform.position = new Vector3(-5, height, -1);
        }
        else if (j == 2)
        {
            endnum.transform.position = new Vector3(-4, height, -1);
        }
        move3 = false;
        j++;
    }
    void Joff()
    {
        j = 1;
    }
}
