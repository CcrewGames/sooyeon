using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBundleScript : MonoBehaviour
{
    public GameObject attacknumber;
    public GameObject bundle;
    public GameObject Canvas;

    public int going;
    public int who; //1 칼, 2 큘
    public int damaged1, damaged2, damaged3, damaged4, damaged5;

    GameObject num1, num2, num3, num4, num5;
    public int anum1, anum2, anum3, anum4, anum5;

    public bool nummove;
    float speed = 5;
    float x0 = 0;
    float y0 = 0;
    public float x1, x2, x3, x4, x5;
    public float y1, y2, y3, y4, y5;

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
        //bundle.SetActive(false);
        going = 0;

        num1 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num2 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num3 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num4 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);
        num5 = Instantiate(attacknumber, new Vector2(x0, y0), transform.rotation);

        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        num4.SetActive(false);
        num5.SetActive(false);

        damaged1 = 0;
        damaged2 = 0;
        damaged3 = 0;
        damaged4 = 0;
        damaged5 = 0;
        who = 0;
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
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Stage").GetComponent<Stage3>().pausemode == false && going == 1)
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
                    who = 1;

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
                    who = 1;

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
                    who = 1;

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
                    who = 1;

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
                    who = 1;

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
        }
    }

    public void numbunOn()
    {
        //bundle.SetActive(true);

        randomallsetting();

        going = 1;
    }

    public void numbunOff()
    {
        going = 0;
        nummove = false;
        //bundle.SetActive(false);

        Destroy(num1);
        Destroy(num2);
        Destroy(num3);
        Destroy(num4);
        Destroy(num5);
    }

    void randomallsetting()
    {
        anum1 = Random.Range(10, 30);
        anum2 = Random.Range(10, 30);
        anum3 = Random.Range(10, 30);
        anum4 = Random.Range(10, 30);
        anum5 = Random.Range(10, 30);

        x1 = -3;
        x2 = -2;
        x3 = 0;
        x4 = 2;
        x5 = 3;

        y1 = -0.5f;
        y2 = 1;
        y3 = 2;
        y4 = 1;
        y5 = -0.5f;

        num1.GetComponent<NumberScript>().y0 = y1;
        num2.GetComponent<NumberScript>().y0 = y2;
        num3.GetComponent<NumberScript>().y0 = y3;
        num4.GetComponent<NumberScript>().y0 = y4;
        num5.GetComponent<NumberScript>().y0 = y5;
        num1.GetComponent<NumberScript>().y1 = y1 - 0.05f;
        num2.GetComponent<NumberScript>().y1 = y2 - 0.05f;
        num3.GetComponent<NumberScript>().y1 = y3 - 0.05f;
        num4.GetComponent<NumberScript>().y1 = y4 - 0.05f;
        num5.GetComponent<NumberScript>().y1 = y5 - 0.05f;

        num1.GetComponent<NumberScript>().result = anum1;
        num2.GetComponent<NumberScript>().result = anum2;
        num3.GetComponent<NumberScript>().result = anum3;
        num4.GetComponent<NumberScript>().result = anum4;
        num5.GetComponent<NumberScript>().result = anum5;

        num1.GetComponent<NumberScript>().nummaker();
        num2.GetComponent<NumberScript>().nummaker();
        num3.GetComponent<NumberScript>().nummaker();
        num4.GetComponent<NumberScript>().nummaker();
        num5.GetComponent<NumberScript>().nummaker();

        nummove = true;

        num1.SetActive(true);
        num2.SetActive(true);
        num3.SetActive(true);
        num4.SetActive(true);
        num5.SetActive(true);
    }

    public void num1setting()
    {
        if (damaged1 == 0)
        {
            if (who == 1)
            {
                KalUp();
            }
            else
            {
                CulUp();
            }
            damaged1 = who;
        }
        Invoke("num1damaged", 0.7f);
        num1.SetActive(false);
        Invoke("num1setting_", 0.5f);
    }
    void num1setting_()
    {
        anum1 = Random.Range(10, 30);
        num1.GetComponent<NumberScript>().result = anum1;
        num1.GetComponent<NumberScript>().nummaker();
        num1.SetActive(true);
        num1.transform.position = new Vector2(x0, y0);
    }

    public void num2setting()
    {
        if (damaged2 == 0)
        {
            if (who == 1)
            {
                KalUp();
            }
            else
            {
                CulUp();
            }
            damaged2 = who;
        }
        Invoke("num2damaged", 0.7f);
        num2.SetActive(false);
        Invoke("num2setting_", 0.5f);
    }
    void num2setting_()
    {
        anum2 = Random.Range(10, 30);
        num2.GetComponent<NumberScript>().result = anum2;
        num2.GetComponent<NumberScript>().nummaker();
        num2.SetActive(true);
        num2.transform.position = new Vector2(x0, y0);
    }

    public void num3setting()
    {
        if (damaged3 == 0)
        {
            if (who == 1)
            {
                KalUp();
            }
            else
            {
                CulUp();
            }
            damaged3 = who;
        }
        Invoke("num3damaged", 0.7f);
        num3.SetActive(false);
        Invoke("num3setting_", 0.5f);
    }
    void num3setting_()
    {
        anum3 = Random.Range(10, 30);
        num3.GetComponent<NumberScript>().result = anum3;
        num3.GetComponent<NumberScript>().nummaker();
        num3.SetActive(true);
        num3.transform.position = new Vector2(x0, y0);
    }

    public void num4setting()
    {
        if (damaged4 == 0)
        {
            if (who == 1)
            {
                KalUp();
            }
            else
            {
                CulUp();
            }
            damaged4 = who;
        }
        Invoke("num4damaged", 0.7f);
        num4.SetActive(false);
        Invoke("num4setting_", 0.5f);
    }
    void num4setting_()
    {
        anum4 = Random.Range(10, 30);
        num4.GetComponent<NumberScript>().result = anum4;
        num4.GetComponent<NumberScript>().nummaker();
        num4.SetActive(true);
        num4.transform.position = new Vector2(x0, y0);
    }

    public void num5setting()
    {
        if(damaged5 == 0)
        {
            if (who == 1)
            {
                KalUp();
            }
            else
            {
                CulUp();
            }
            damaged5 = who;
        }
        Invoke("num5damaged", 0.7f);
        num5.SetActive(false);
        Invoke("num5setting_", 0.5f);
    }
    void num5setting_()
    {
        anum5 = Random.Range(10, 30);
        num5.GetComponent<NumberScript>().result = anum5;
        num5.GetComponent<NumberScript>().nummaker();
        num5.SetActive(true);
        num5.transform.position = new Vector2(x0, y0);
    }

    public void num1damaged()
    {
        damaged1 = 0;
        who = 0;
    }
    public void num2damaged()
    {
        damaged2 = 0;
        who = 0;
    }
    public void num3damaged()
    {
        damaged3 = 0;
        who = 0;
    }
    public void num4damaged()
    {
        damaged4 = 0;
        who = 0;
    }
    public void num5damaged()
    {
        damaged5 = 0;
        who = 0;
    }

    public void KalUp()
    {
        Canvas.GetComponent<FightBarScript>().fighthbar += 1;
    }
    public void CulUp()
    {
        Canvas.GetComponent<FightBarScript>().fighthbar -= 1;
    }
}
