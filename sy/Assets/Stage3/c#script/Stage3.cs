//스테이지 3
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3 : MonoBehaviour
{
    public GameObject canvas;
    public GameObject ending;
    public GameObject FightBar;
    public GameObject HpPlayer;
    public GameObject punch;

    public GameObject Pause;
    public GameObject Resume;
    public bool pausemode;

    public int stage; //현재 단계 확인용 변수
    public bool stagemove; //단계 사이 이동 시간 확보용 변수
    public int fortime; //시간 흐르게 하기 위한 변수

    public int remain; //단계별 남은 몬스터 수 확인용 변수

    public GameObject monster;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public int monstermove;
    GameObject mon1;
    GameObject mon2;
    GameObject mon3;
    GameObject mon4;
    float x1 = 20f;
    float x2 = 20f;
    float x3 = 20f;
    float x4 = 20f;
    float y1 = -0.8f;
    float y2 = -1.4f;
    float y3 = -0.6f;
    float y4 = -1.2f;

    //칼 날라가기~
    public GameObject AttackBar1;
    GameObject fly;
    float xk = -6.5f;
    float yk = 2.8f;
    public float xf;
    public float yf;
    float speed = 7.5f;
    bool flymode;

    //큘
    public GameObject Cul;

    public int monnum2;
    public int numnum;

    public float story;

    GameObject ForDestroy;

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

    public void Start() //게임 시작 초기화
    {
        FightBar.SetActive(false);

        ResumeMode();

        stage = 0;
        stagemove = true;
        remain = 0;

        monstermove = 0;
        
        monnum2 = 0;

        story = 0;

        fly = Instantiate(AttackBar1, new Vector2(xk, yk), transform.rotation);
        fly.SetActive(false);
        flymode = false;
    }

    void FixedUpdate()
    {
        if (flymode == true)
        {
            fly.transform.position = Vector2.Lerp(fly.transform.position, new Vector2(xf, yf), Time.deltaTime * speed);
        }
        if (fly.transform.position.x >= xf - 1f && flymode == true)
        {
            Flyoff();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && story == 0)
        {
            CastRay();

            if (target == Pause)
            {
                PauseMode();
            }
            else if (target == Resume)
            {
                ResumeMode();
            }
        }

        if (stage == 0 && remain == 0) //1단계 준비
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            GameObject.Find("Player").GetComponent<KalScript>().HealStop();

            MonsterSpawn();

            GameObject.Find("Player").GetComponent<KalScript>().Run();
            Invoke("StageMove", 13f);

            remain = 4;
        }

        if (stage == 1 && stagemove == false) //1단계 시작
        {
            fortime = 1;
            punch.GetComponent<PunchScript>().ScrollChange2();

            punch.GetComponent<PunchScript>().punchmode = 1;
            punch.GetComponent<PunchScript>().PunchMode();

            MonNum();
            mon1.GetComponent<MonsterScript>().Layer();
            mon2.GetComponent<MonsterScript>().Layer();
            mon3.GetComponent<MonsterScript2>().Layer();
            mon4.GetComponent<MonsterScript2>().Layer();

            GameObject.Find("Story").GetComponent<Story3Script>().Story1_2On();
            Invoke("CulSkill1", 0.5f);

            stagemove = true;
        }

        if (stage == 1 && remain == 0) //1단계 종료
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            HpPlayer.SetActive(false);

            GameObject.Find("Player").GetComponent<KalScript>().HealStop();
            GameObject.Find("Player").GetComponent<KalScript>().Run();

            Invoke("StageMove", 13f);

            remain = 1;
        }

        if (stage == 2 && stagemove == false) //2단계 시작
        {
            fortime = 1;
            punch.GetComponent<PunchScript>().ScrollChange2();

            GameObject.Find("Story").GetComponent<Story3Script>().Story2On();
            Cul.GetComponent<CulScript>().AttackBarOn();
            Invoke("CulSkill2", 1f);

            stagemove = true;
        }
        
        if (stage == 3 && stagemove == false) //클리어
        {
            StageEnding();

            stagemove = true;
        }
    }

    public void PauseMode()
    {
        Time.timeScale = 0;
        pausemode = true;
        GameObject.Find("buttonclick").GetComponent<Buttonclick>().pausemode = true;
        Pause.SetActive(false);
        Resume.SetActive(true);
    }
    public void ResumeMode()
    {
        Time.timeScale = 1;
        pausemode = false;
        GameObject.Find("buttonclick").GetComponent<Buttonclick>().pausemode = false;
        Pause.SetActive(true);
        Resume.SetActive(false);
    }

    void StageMove() //단계 사이 이동 시간 확보용 함수
    {
        stage++;
        stagemove = false;
    }

    void MonsterSpawn()
    {
        if (stage == 0)
        {
            mon1 = Instantiate(monster, new Vector2(x1, y1), transform.rotation);
            mon2 = Instantiate(monster2, new Vector2(x2, y2), transform.rotation);
            mon3 = Instantiate(monster3, new Vector2(x3, y3), transform.rotation);
            mon4 = Instantiate(monster4, new Vector2(x4, y4), transform.rotation);
            mon1.GetComponent<MonsterScript>().stage = 3;
            mon2.GetComponent<MonsterScript>().stage = 3;
            mon3.GetComponent<MonsterScript2>().stage = 3;
            mon4.GetComponent<MonsterScript2>().stage = 3;
            mon1.SetActive(true);
            mon2.SetActive(true);
            mon3.SetActive(true);
            mon4.SetActive(true);
        }
    }

    void MonNum()
    {
        mon1.GetComponent<MonsterScript>().monnum = 1;
        mon2.GetComponent<MonsterScript>().monnum = 2;
        mon3.GetComponent<MonsterScript2>().monnum = 4;
        mon4.GetComponent<MonsterScript2>().monnum = 5;
    }

    public void Fly()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("attack");
        fly.SetActive(true);
        flymode = true;

        float r1 = Mathf.Atan2(yf - yk, xf - xk) * Mathf.Rad2Deg;
        if (r1 < -30)
        {
            r1 = -30;
        }
        fly.transform.rotation = Quaternion.Euler(0, 0, r1);
    }
    public void Flyoff()
    {
        if (monnum2 == 1)
        {
            mon1.GetComponent<MonsterScript>().OnDamaged();
        }
        else if (monnum2 == 2)
        {
            mon2.GetComponent<MonsterScript>().OnDamaged();
        }
        else if (monnum2 == 4)
        {
            mon3.GetComponent<MonsterScript2>().OnDamaged();
        }
        else if (monnum2 == 5)
        {
            mon4.GetComponent<MonsterScript2>().OnDamaged();
        }
        else if (monnum2 == 6)
        {
            if(numnum == 1)
            {
                GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num1setting();
            }
            else if (numnum == 2)
            {
                GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num2setting();
            }
            else if (numnum == 3)
            {
                GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num3setting();
            }
            else if (numnum == 4)
            {
                GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num4setting();
            }
            else if (numnum == 5)
            {
                GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num5setting();
            }
        }
        monnum2 = 0;

        fly.transform.position = new Vector2(xk, yk);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode = false;
        punch.GetComponent<PunchScript>().punchmode = 1;
        punch.GetComponent<PunchScript>().PunchMode();
        punch.GetComponent<PunchScript>().ScrollChange2();
    }

    public void CulSkill1()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("surprise");
        mon1.transform.position = new Vector2(Cul.transform.position.x + 1, y1);
        mon2.transform.position = new Vector2(Cul.transform.position.x + 4, y2);
        mon3.transform.position = new Vector2(Cul.transform.position.x + 7, y3);
        mon4.transform.position = new Vector2(Cul.transform.position.x + 10, y4);
        mon1.GetComponent<MonsterScript>().respawn2();
        mon2.GetComponent<MonsterScript>().respawn2();
        mon3.GetComponent<MonsterScript2>().respawn2();
        mon4.GetComponent<MonsterScript2>().respawn2();
        Cul.GetComponent<CulScript>().move2();
    }
    public void CulSkill2()
    {
        GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().numbunOn();
        GameObject.Find("Cul").GetComponent<CulScript>().Timer();
        FightBar.SetActive(true);
    }

    public void Win()
    {
        punch.GetComponent<PunchScript>().punchmode = 0;
        punch.GetComponent<PunchScript>().PunchMode();
        FightBar.SetActive(false);
        GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().numbunOff();
        Invoke("Story2_2", 3f);
    }

    public void Lose()
    {
        punch.GetComponent<PunchScript>().punchmode = 0;
        punch.GetComponent<PunchScript>().PunchMode();
        FightBar.SetActive(false);
        GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().numbunOff();
    }

    public void Story2_2()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story2_2On();
        Invoke("NextStory", 1f);
    }
    public void NextStory()
    {
        Cul.GetComponent<CulScript>().KiloProtoOn();
    }

    public void StageEnding()
    {
        if (ending != null)
        {
            ending.GetComponent<endingscene3>().endingStart();
        }
    }
}