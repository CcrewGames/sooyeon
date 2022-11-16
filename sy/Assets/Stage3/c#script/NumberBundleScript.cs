using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBundleScript : MonoBehaviour
{
    public GameObject timebox;
    public GameObject timecount;
    public GameObject attacknumber;
    public GameObject bundle;

    public int fortime;

    GameObject num1, num2, num3, num4, num5, num6;
    public int anum1, anum2, anum3, anum4, anum5, anum6;

    public bool nummove;
    float speed = 5;
    float x0 = 0;
    float y0 = 0;
    float x1, x2, x3;
    float x4, x5, x6;
    float y1, y2, y3, y4, y5, y6;

    private GameObject target; //마우스 클릭 확인용 변수
    void CastRay() //마우스 클릭 확인용 함수
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }

    void Start()
    {
        timebox.SetActive(false);
        timecount.SetActive(false);
        //bundle.SetActive(false);
        fortime = 0;

        num1 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num2 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num3 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num4 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num5 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num6 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);

        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        num4.SetActive(false);
        num5.SetActive(false);
        num6.SetActive(false);
    }

    void FixedUpdate()
    {
        if(nummove == true)
        {
            num1.transform.position = Vector3.Slerp(num1.transform.position, new Vector2(x1, y1), Time.deltaTime * speed);
            num2.transform.position = Vector3.Slerp(num2.transform.position, new Vector2(x2, y2), Time.deltaTime * speed);
            num3.transform.position = Vector3.Slerp(num3.transform.position, new Vector2(x3, y3), Time.deltaTime * speed);
            num4.transform.position = Vector3.Slerp(num4.transform.position, new Vector2(x4, y4), Time.deltaTime * speed);
            num5.transform.position = Vector3.Slerp(num5.transform.position, new Vector2(x5, y5), Time.deltaTime * speed);
            num6.transform.position = Vector3.Slerp(num6.transform.position, new Vector2(x6, y6), Time.deltaTime * speed);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Stage").GetComponent<Stage3>().pausemode == false && fortime == 1)
        {
            CastRay();

            if (target == num1)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == anum1) //난수 = 결과 일치
                {
                    GameObject.Find("Stage").GetComponent<Stage3>().xf = x1 - 0.5f;
                    GameObject.Find("Stage").GetComponent<Stage3>().yf = y1;
                    GameObject.Find("Stage").GetComponent<Stage3>().monnum2 = 6;
                    GameObject.Find("Stage").GetComponent<Stage3>().numnum = 1;

                    GameObject.Find("Stage").GetComponent<Stage3>().Fly();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                }
                else
                {
                    if (num1.GetComponent<NumberScript>().tremble == false)
                    {
                        num1.GetComponent<NumberScript>().Tremble();
                    }
                }
            }
            if (target == num2)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == anum2) //난수 = 결과 일치
                {
                    GameObject.Find("Stage").GetComponent<Stage3>().xf = x2 - 0.5f;
                    GameObject.Find("Stage").GetComponent<Stage3>().yf = y2;
                    GameObject.Find("Stage").GetComponent<Stage3>().monnum2 = 6;
                    GameObject.Find("Stage").GetComponent<Stage3>().numnum = 2;

                    GameObject.Find("Stage").GetComponent<Stage3>().Fly();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                }
                else
                {
                    if(num2.GetComponent<NumberScript>().tremble == false)
                    {
                        num2.GetComponent<NumberScript>().Tremble();
                    }
                }
            }
            if (target == num3)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == anum3) //난수 = 결과 일치
                {
                    GameObject.Find("Stage").GetComponent<Stage3>().xf = x3 - 0.5f;
                    GameObject.Find("Stage").GetComponent<Stage3>().yf = y3;
                    GameObject.Find("Stage").GetComponent<Stage3>().monnum2 = 6;
                    GameObject.Find("Stage").GetComponent<Stage3>().numnum = 3;

                    GameObject.Find("Stage").GetComponent<Stage3>().Fly();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                }
                else
                {
                    if (num3.GetComponent<NumberScript>().tremble == false)
                    {
                        num3.GetComponent<NumberScript>().Tremble();
                    }
                }
            }
            if (target == num4)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == anum4) //난수 = 결과 일치
                {
                    GameObject.Find("Stage").GetComponent<Stage3>().xf = x4 - 0.5f;
                    GameObject.Find("Stage").GetComponent<Stage3>().yf = y4;
                    GameObject.Find("Stage").GetComponent<Stage3>().monnum2 = 6;
                    GameObject.Find("Stage").GetComponent<Stage3>().numnum = 4;

                    GameObject.Find("Stage").GetComponent<Stage3>().Fly();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                }
                else
                {
                    if (num4.GetComponent<NumberScript>().tremble == false)
                    {
                        num4.GetComponent<NumberScript>().Tremble();
                    }
                }
            }
            if (target == num5)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == anum5) //난수 = 결과 일치
                {
                    GameObject.Find("Stage").GetComponent<Stage3>().xf = x5 - 0.5f;
                    GameObject.Find("Stage").GetComponent<Stage3>().yf = y5;
                    GameObject.Find("Stage").GetComponent<Stage3>().monnum2 = 6;
                    GameObject.Find("Stage").GetComponent<Stage3>().numnum = 5;

                    GameObject.Find("Stage").GetComponent<Stage3>().Fly();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                }
                else
                {
                    if (num5.GetComponent<NumberScript>().tremble == false)
                    {
                        num5.GetComponent<NumberScript>().Tremble();
                    }
                }
            }
            if (target == num6)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == anum6) //난수 = 결과 일치
                {
                    GameObject.Find("Stage").GetComponent<Stage3>().xf = x6 - 0.5f;
                    GameObject.Find("Stage").GetComponent<Stage3>().yf = y6;
                    GameObject.Find("Stage").GetComponent<Stage3>().monnum2 = 6;
                    GameObject.Find("Stage").GetComponent<Stage3>().numnum = 6;

                    GameObject.Find("Stage").GetComponent<Stage3>().Fly();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                }
                else
                {
                    if (num6.GetComponent<NumberScript>().tremble == false)
                    {
                        num6.GetComponent<NumberScript>().Tremble();
                    }
                }
            }
        }
    }

    public void numbunOn()
    {
        timebox.SetActive(true);
        timecount.SetActive(true);
        //bundle.SetActive(true);

        randomallsetting();

        fortime = 1;
    }

    public void numbunOff()
    {
        fortime = 0;
        nummove = false;
        timebox.SetActive(false);
        timecount.SetActive(false);
        //bundle.SetActive(false);

        Destroy(num1);
        Destroy(num2);
        Destroy(num3);
        Destroy(num4);
        Destroy(num5);
        Destroy(num6);
    }

    void randomallsetting()
    {
        anum1 = Random.Range(10, 30);
        anum2 = Random.Range(10, 30);
        anum3 = Random.Range(10, 30);
        anum4 = Random.Range(10, 30);
        anum5 = Random.Range(10, 30);
        anum6 = Random.Range(10, 30);

        x1 = Random.Range(-4, 0);
        x2 = Random.Range(-4, 0);
        x3 = Random.Range(-4, 0);
        x4 = Random.Range(0, 4);
        x5 = Random.Range(0, 4);
        x6 = Random.Range(0, 4);

        y1 = Random.Range(-1, 2);
        y2 = Random.Range(-1, 2);
        y3 = Random.Range(-1, 2);
        y4 = Random.Range(-1, 2);
        y5 = Random.Range(-1, 2);
        y6 = Random.Range(-1, 2);
        
        num1.GetComponent<NumberScript>().result = anum1;
        num2.GetComponent<NumberScript>().result = anum2;
        num3.GetComponent<NumberScript>().result = anum3;
        num4.GetComponent<NumberScript>().result = anum4;
        num5.GetComponent<NumberScript>().result = anum5;
        num6.GetComponent<NumberScript>().result = anum6;

        num1.GetComponent<NumberScript>().nummaker();
        num2.GetComponent<NumberScript>().nummaker();
        num3.GetComponent<NumberScript>().nummaker();
        num4.GetComponent<NumberScript>().nummaker();
        num5.GetComponent<NumberScript>().nummaker();
        num6.GetComponent<NumberScript>().nummaker();

        nummove = true;

        num1.SetActive(true);
        num2.SetActive(true);
        num3.SetActive(true);
        num4.SetActive(true);
        num5.SetActive(true);
        num6.SetActive(true);
    }

    public void num1setting()
    {
        num1.SetActive(false);
        Invoke("num1setting_", 0.5f);
        x1 = x0;
        y1 = y0;
    }
    void num1setting_()
    {
        anum1 = Random.Range(10, 30);
        num1.GetComponent<NumberScript>().result = anum1;
        num1.GetComponent<NumberScript>().nummaker();
        num1.SetActive(true);
        x1 = Random.Range(-4, 0);
        y1 = Random.Range(-1, 2);
        num1.transform.position = new Vector2(x0, y0);
    }

    public void num2setting()
    {
        num2.SetActive(false);
        Invoke("num2setting_", 0.5f);
        x2 = x0;
        y2 = y0;
    }
    void num2setting_()
    {
        anum2 = Random.Range(10, 30);
        num2.GetComponent<NumberScript>().result = anum2;
        num2.GetComponent<NumberScript>().nummaker();
        num2.SetActive(true);
        x2 = Random.Range(-4, 0);
        y2 = Random.Range(-1, 2);
        num2.transform.position = new Vector2(x0, y0);
    }

    public void num3setting()
    {
        num3.SetActive(false);
        Invoke("num3setting_", 0.5f);
        x3 = x0;
        y3 = y0;
    }
    void num3setting_()
    {
        anum3 = Random.Range(10, 30);
        num3.GetComponent<NumberScript>().result = anum3;
        num3.GetComponent<NumberScript>().nummaker();
        num3.SetActive(true);
        x3 = Random.Range(-4, 0);
        y3 = Random.Range(-1, 2);
        num3.transform.position = new Vector2(x0, y0);
    }
    public void num4setting()
    {
        num4.SetActive(false);
        Invoke("num4setting_", 0.5f);
        x4 = x0;
        y4 = y0;
    }
    void num4setting_()
    {
        anum4 = Random.Range(10, 30);
        num4.GetComponent<NumberScript>().result = anum4;
        num4.GetComponent<NumberScript>().nummaker();
        num4.SetActive(true);
        x4 = Random.Range(0, 4);
        y4 = Random.Range(-1, 2);
        num4.transform.position = new Vector2(x0, y0);
    }

    public void num5setting()
    {
        num5.SetActive(false);
        Invoke("num5setting_", 0.5f);
        x5 = x0;
        y5 = y0;
    }
    void num5setting_()
    {
        anum5 = Random.Range(10, 30);
        num5.GetComponent<NumberScript>().result = anum5;
        num5.GetComponent<NumberScript>().nummaker();
        num5.SetActive(true);
        x5 = Random.Range(0, 4);
        y5 = Random.Range(-1, 2);
        num5.transform.position = new Vector2(x0, y0);
    }

    public void num6setting()
    {
        num6.SetActive(false);
        Invoke("num6setting_", 0.5f);
        x6 = x0;
        y6 = y0;
    }
    void num6setting_()
    {
        anum6 = Random.Range(10, 30);
        num6.GetComponent<NumberScript>().result = anum6;
        num6.GetComponent<NumberScript>().nummaker();
        num6.SetActive(true);
        x6 = Random.Range(0, 4);
        y6 = Random.Range(-1, 2);
        num6.transform.position = new Vector2(x0, y0);
    }
}
