using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBarScript : MonoBehaviour
{
    public GameObject punch;

    public GameObject number;
    private GameObject num;
    private GameObject num1;
    private GameObject num2;
    private GameObject sign;
    private GameObject endnum;
    
    int i;
    int j;
    bool move1; //가운데로 모으기
    bool move2; //왼쪽으로 보내기
    bool move3; //날아오게 하기

    float speed = 3f;
    float time = 0.3f;
    float dis = 0.2f;

    float time1 = 0.5f;

    float height = 2.5f;

    Vector2 MousePosition;

    Camera Camera;

    void Start()
    {
        num = Instantiate(number, new Vector3(-5, height, 0), transform.rotation);
        num1 = Instantiate(number, new Vector3(-5, height, 0), transform.rotation);
        num2 = Instantiate(number, new Vector3(-5, height, 0), transform.rotation);
        sign = Instantiate(number, new Vector3(-5, height, 0), transform.rotation);
        endnum = Instantiate(number, new Vector3(-5, height, 0), transform.rotation);

        re();

        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void re()
    {
        num.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);
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
    }

    public void nummaker()
    {
        Sprite[] spritesN = Resources.LoadAll<Sprite>("number");
        Sprite[] spritesM = Resources.LoadAll<Sprite>("sign");
        if (i == 0)
        {
            num.transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);
            move3 = true;
            Invoke("Stop3", time1);

            num.SetActive(true);
            SpriteRenderer spriteJ = num.GetComponent<SpriteRenderer>();
            spriteJ.sprite = spritesN[punch.GetComponent<PunchScript>().attack[0]];

            i++;
        }
        else if (i == 1)
        {
            move2 = true;
            Invoke("Stop2", time);

            sign.transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);
            move3 = true;
            Invoke("Stop3", time1);

            sign.SetActive(true);

            SpriteRenderer spriteK = sign.GetComponent<SpriteRenderer>();
            spriteK.sprite = spritesM[punch.GetComponent<PunchScript>().attack[1] - 1];

            i++;
        }
        else if (i == 2)
        {
            endnum.transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);
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
    void Run1() //가운데로 모으기
    {
        num.transform.position = Vector3.Lerp(num.transform.position, new Vector3(-5, height, 0), Time.deltaTime * speed);
        num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-5, height, 0), Time.deltaTime * speed);
        num2.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-5, height, 0), Time.deltaTime * speed);
        endnum.transform.position = Vector3.Lerp(endnum.transform.position, new Vector3(-5, height, 0), Time.deltaTime * speed);
    }
    void Stop1()
    {
        move1 = false;
        num.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);
        sign.SetActive(false);
        endnum.SetActive(false);

        Sprite[] spritesN = Resources.LoadAll<Sprite>("number");
        Sprite[] spritesM = Resources.LoadAll<Sprite>("sign");
        if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = new Vector3(-5 - dis, height, 0);
            num2.transform.position = new Vector3(-5 + dis, height, 0);

            int a = punch.GetComponent<PunchScript>().result / 10;
            int b = punch.GetComponent<PunchScript>().result % 10;

            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = spritesN[a];
            SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
            spriteB.sprite = spritesN[b];

            num.SetActive(false);
            num2.SetActive(true);
            num1.SetActive(true);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            SpriteRenderer spriteR = num.GetComponent<SpriteRenderer>();
            spriteR.sprite = spritesN[punch.GetComponent<PunchScript>().result];

            num.SetActive(true);
            num2.SetActive(false);
            num1.SetActive(false);
        }
    }

    void Run2() //왼쪽으로 보내기
    {
        if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = Vector3.Lerp(num1.transform.position, new Vector3(-6 - dis, height, 0), Time.deltaTime * speed);
            num2.transform.position = Vector3.Lerp(num2.transform.position, new Vector3(-6 + dis, height, 0), Time.deltaTime * speed);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num.transform.position = Vector3.Lerp(num.transform.position, new Vector3(-6, height, 0), Time.deltaTime * speed);
        }
    }
    void Stop2()
    {
        if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = new Vector3(-6 - dis, height, 0);
            num2.transform.position = new Vector3(-6 + dis, height, 0);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num.transform.position = new Vector3(-6, height, 0);
        }
        move2 = false;
    }

    void Run3() //날아가게 하기
    {
        if (j == 0)
        {
            num.transform.position = Vector3.Lerp(num.transform.position, new Vector3(-5, height, 0), Time.deltaTime * 8);
        }
        else if (j == 1)
        {
            sign.transform.position = Vector3.Lerp(sign.transform.position, new Vector3(-5, height, 0), Time.deltaTime * 8);
        }
        else if (j == 2)
        {
            endnum.transform.position = Vector3.Lerp(endnum.transform.position, new Vector3(-4, height, 0), Time.deltaTime * 8);
        }
    }
    void Stop3()
    {
        if (j == 0)
        {
            num.transform.position = new Vector3(-5, height, 0);
        }
        else if (j == 1)
        {
            sign.transform.position = new Vector3(-5, height, 0);
        }
        else if (j == 2)
        {
            endnum.transform.position = new Vector3(-4, height, 0);
        }
        move3 = false;
        j++;
    }
    void Joff()
    {
        j = 1;
    }
}
