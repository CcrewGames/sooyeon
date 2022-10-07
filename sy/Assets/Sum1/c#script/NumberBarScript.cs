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
    bool first;
    bool move1;
    bool move2;
    bool move3;
    float speed = 3f;
    float time = 0.3f;
    float dis = 0.2f;

    Vector3 endpos;
    Vector2 MousePosition;

    Camera Camera;

    void Start()
    {
        num = Instantiate(number, new Vector3(-5, 3, 1), transform.rotation);
        num1 = Instantiate(number, new Vector3(-5, 3, 1), transform.rotation);
        num2 = Instantiate(number, new Vector3(-5, 3, 1), transform.rotation);
        sign = Instantiate(number, new Vector3(-5, 3, 1), transform.rotation);
        endnum = Instantiate(number, new Vector3(-5, 3, 1), transform.rotation);

        num.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);
        sign.SetActive(false);
        endnum.SetActive(false);

        i = 0;
        j = 0;
        first = true;
        move1 = false;
        move2 = false;

        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
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
            num.transform.position = new Vector3(-6, 3, 1);
            //num.transform.position = new Vector3(MousePosition.x, MousePosition.y, 1);
            //move3 = true;
            //Invoke("Stop3", time);

            num.SetActive(true);
            SpriteRenderer spriteJ = num.GetComponent<SpriteRenderer>();
            spriteJ.sprite = spritesN[punch.GetComponent<PunchScript>().attack[0]];

            i++;
        }
        else if (i == 1)
        {
            if (first == true)
            {
                sign.transform.position = new Vector3(-5, 3, 1);
                //sign.transform.position = new Vector3(MousePosition.x, MousePosition.y, 1);
                //move3 = true;
                //Invoke("Stop3", time);

                sign.SetActive(true);

                SpriteRenderer spriteK = sign.GetComponent<SpriteRenderer>();
                spriteK.sprite = spritesM[punch.GetComponent<PunchScript>().attack[1] - 1];

                i++;
                first = false;
            }
            else
            {
                sign.transform.position = new Vector3(-5, 3, 1);
                //sign.transform.position = new Vector3(MousePosition.x, MousePosition.y, 1);
                //move3 = true;
                //Invoke("Stop3", time);

                move2 = true;
                Invoke("Stop2", time);

                sign.SetActive(true);

                SpriteRenderer spriteK = sign.GetComponent<SpriteRenderer>();
                spriteK.sprite = spritesM[punch.GetComponent<PunchScript>().attack[1] - 1];

                i++;
            }
        }
        else if (i == 2)
        {
            endnum.transform.position = new Vector3(-4, 3, 1);
            //endnum.transform.position = new Vector3(MousePosition.x, MousePosition.y, 1);
            //move3 = true;
            //Invoke("Stop3", time);
            //Invoke("Joff", time);

            endnum.SetActive(true);

            SpriteRenderer spriteL = endnum.GetComponent<SpriteRenderer>();
            spriteL.sprite = spritesN[punch.GetComponent<PunchScript>().attack[2]];

            move1 = true;
            Invoke("Stop1", time);
            i = 1;
        }
    }

    void Run1()
    {
        num.transform.position = Vector3.MoveTowards(num.transform.position, new Vector3(-5, 3, 1), Time.deltaTime * speed);
        num1.transform.position = Vector3.MoveTowards(num1.transform.position, new Vector3(-5, 3, 1), Time.deltaTime * speed);
        num2.transform.position = Vector3.MoveTowards(num1.transform.position, new Vector3(-5, 3, 1), Time.deltaTime * speed);
        endnum.transform.position = Vector3.MoveTowards(endnum.transform.position, new Vector3(-5, 3, 1), Time.deltaTime * speed);
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
            num1.transform.position = new Vector3(-5 - dis, 3, 1);
            num2.transform.position = new Vector3(-5 + dis, 3, 1);

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

    void Run2()
    {
        if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = Vector3.MoveTowards(num1.transform.position, new Vector3(-6 - dis, 3, 1), Time.deltaTime * speed);
            num2.transform.position = Vector3.MoveTowards(num2.transform.position, new Vector3(-6 + dis, 3, 1), Time.deltaTime * speed);
        }
        else if (punch.GetComponent<PunchScript>().result > 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num.transform.position = Vector3.MoveTowards(num.transform.position, new Vector3(-6, 3, 1), Time.deltaTime * speed);
        }
    }

    void Stop2()
    {
        move2 = false;
    }
    void Run3()
    {
        if (j == 0)
        {
            num.transform.position = Vector3.MoveTowards(new Vector3(MousePosition.x, MousePosition.y, 1), new Vector3(-6, 3, 1), Time.deltaTime * speed);
        }
        else if (j == 1)
        {
            sign.transform.position = Vector3.MoveTowards(new Vector3(MousePosition.x, MousePosition.y, 1), new Vector3(-5, 3, 1), Time.deltaTime * speed);
        }
        else if (j == 2)
        {
            endnum.transform.position = Vector3.MoveTowards(new Vector3(MousePosition.x, MousePosition.y, 1), new Vector3(-4, 3, 1), Time.deltaTime * speed);
        }
    }

    void Stop3()
    {
        move3 = false;
        j++;
    }

    void Joff()
    {
        j = 1;
    }
}
