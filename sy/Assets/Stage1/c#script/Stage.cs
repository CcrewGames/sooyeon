//스테이지 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Resume;
    public bool pausemode;

    public int stage; //현재 단계 확인용 변수
    public bool stagemove; //단계 사이 이동 시간 확보용 변수
    public int fortime; //시간 흐르게 하기 위한 변수

    public int remain; //단계별 남은 몬스터 수 확인용 변수

    public GameObject canvas;
    public GameObject text;

    public GameObject monster;
    public GameObject monster2;
    public int monstermove;
    GameObject mon1;
    GameObject mon2;
    GameObject mon3;
    float x1 = 16.5f;
    float x2 = 19.5f;
    float x3 = 22.5f;
    float y1 = -0.8f;
    float y2 = -1.6f;
    float y3 = -1.2f;

    public GameObject BossMonster;
    public GameObject boss;
    float x4 = 14f;
    float y4 = 0.02f;
    public GameObject BH;
    public GameObject BHBB;
    public Image bombtimer;
    public float xb;
    public float yb;

    public GameObject punch;

    public GameObject ending;

    //칼 날라가기~
    public GameObject AttackBar;
    GameObject fly;
    float x5 = -6.5f;
    float y5 = 2.8f;
    public float xf;
    public float yf;
    float speed = 7.5f;
    bool flymode;
    bool flymode1;

    public bool bossdie;

    public int monnum2;

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
        ResumeMode();

        text.SetActive(false);

        stage = 1;
        stagemove = true;
        remain = 0;

        monstermove = 0;
        bossdie = false;

        monnum2 = 0;

        story = 0;

        fly = Instantiate(AttackBar, new Vector2(x5, y5), transform.rotation);
        fly.SetActive(false);
        flymode = false;
        flymode1 = false;

        BombOff();

        BossHealthbarOff();
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

        if (flymode1 == true)
        {
            fly.transform.position = Vector2.Lerp(fly.transform.position, new Vector2(xf, yf), Time.deltaTime * speed);
        }
        if (fly.transform.position.x >= xf - 0.8f && flymode1 == true)
        {
            Flyoff1();
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

            GameObject.Find("Player").GetComponent<PlayerScript>().HealStop();

            MonsterSpawn();

            GameObject.Find("Player").GetComponent<PlayerScript>().Run();
            Invoke("StageMove", 13f);

            remain = 3;
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
            mon3.GetComponent<MonsterScript>().Layer();

            monstermove = 2;
            MonsterMove();

            canvas.GetComponent<TextScript>().text.text = "Stage 1 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            stagemove = true;
        }

        if (stage == 1 && remain == 0) //1단계 종료
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            GameObject.Find("Player").GetComponent<PlayerScript>().HealStop();

            canvas.GetComponent<TextScript>().text.text = "Stage 1 Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            MonsterSpawn();

            GameObject.Find("Player").GetComponent<PlayerScript>().Run();
            Invoke("StageMove", 13f);

            remain = 3;
        }

        if (stage == 2 && stagemove == false) //2단계 시작
        {
            fortime = 1;
            punch.GetComponent<PunchScript>().ScrollChange2();

            punch.GetComponent<PunchScript>().punchmode = 1;
            punch.GetComponent<PunchScript>().PunchMode();

            MonNum();
            mon1.GetComponent<MonsterScript>().Layer();
            mon2.GetComponent<MonsterScript>().Layer();
            mon3.GetComponent<MonsterScript>().Layer();

            monstermove = 2;
            MonsterMove();

            canvas.GetComponent<TextScript>().text.text = "Stage 2 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            stagemove = true;
        }

        if (stage == 2 && remain == 0) //2단계 종료
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            GameObject.Find("Player").GetComponent<PlayerScript>().HealStop();

            canvas.GetComponent<TextScript>().text.text = "Stage 2 Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            MonsterSpawn();

            GameObject.Find("Player").GetComponent<PlayerScript>().Run();
            Invoke("StageMove", 13f);

            remain = 3;
        }

        if (stage == 3 && stagemove == false) //3단계 시작
        {
            fortime = 1;
            punch.GetComponent<PunchScript>().ScrollChange2();

            punch.GetComponent<PunchScript>().punchmode = 1;
            punch.GetComponent<PunchScript>().PunchMode();

            BossHealthbarOn();

            MonNum();
            mon1.GetComponent<MonsterScript>().Layer();
            mon2.GetComponent<MonsterScript>().Layer();

            canvas.GetComponent<TextScript>().text.text = "Stage 3 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            Invoke("Boss1Skill", 2f);

            stagemove = true;
        }

        if (stage == 3 && remain == 0 && bossdie == true) //클리어
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            GameObject.Find("Player").GetComponent<PlayerScript>().HealStop();

            canvas.GetComponent<TextScript>().text.text = "All Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            GameObject.Find("Player").GetComponent<PlayerScript>().Run_();
            Invoke("StageMove", 8f);

            remain = 3; //얘는 남은 몬스터 수 확인용이 아니라 한 번만 실행되도록 하기 위함
        }

        if (stage == 4 && stagemove == false) //클리어
        {
            StageEnding();

            stagemove = true;
        }
    }

    public void BombTimer()
    {
        bombtimer.fillAmount = boss.GetComponent<Stage1BossScript>().time1 / boss.GetComponent<Stage1BossScript>().timemax;
    }
    public void BombPosition()
    {
        bombtimer.transform.position = new Vector2(xb, yb);
    }
    public void BombOff()
    {
        bombtimer.transform.position = new Vector2(500, 0);
        bombtimer.fillAmount = 1;
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
            mon2 = Instantiate(monster, new Vector2(x2, y2), transform.rotation);
            mon3 = Instantiate(monster, new Vector2(x3, y3), transform.rotation);
            mon1.SetActive(true);
            mon2.SetActive(true);
            mon3.SetActive(true);
        }
        else if (stage == 1)
        {
            mon1 = Instantiate(monster2, new Vector2(x1, y1), transform.rotation);
            mon2 = Instantiate(monster2, new Vector2(x2, y2), transform.rotation);
            mon3 = Instantiate(monster2, new Vector2(x3, y3), transform.rotation);
            mon1.SetActive(true);
            mon2.SetActive(true);
            mon3.SetActive(true);
        }
        else if (stage == 2)
        {
            mon1 = Instantiate(monster, new Vector2(x1, y1), transform.rotation);
            mon2 = Instantiate(monster2, new Vector2(x2, y2), transform.rotation);
            mon1.SetActive(true);
            mon2.SetActive(true);

            boss = Instantiate(BossMonster, new Vector2(x4, y4), transform.rotation);
        }
    }

    public void MonsterMove() //단계 사이 이동 시간 확보용 함수
    {
        if (stage < 2 && monstermove == 1)
        {
            mon1.GetComponent<MonsterScript>().xm = x1 - 7;
            mon2.GetComponent<MonsterScript>().xm = x2 - 7;
            mon3.GetComponent<MonsterScript>().xm = x3 - 7;
            mon1.GetComponent<MonsterScript>().respawn1();
            mon2.GetComponent<MonsterScript>().respawn1();
            mon3.GetComponent<MonsterScript>().respawn1();
        }
        else if (monstermove == 2)
        {
            mon1.GetComponent<MonsterScript>().respawn2();
            mon2.GetComponent<MonsterScript>().respawn2();
            mon3.GetComponent<MonsterScript>().respawn2();
        }
        else if (stage == 2 && monstermove == 1)
        {
            boss.GetComponent<Stage1BossScript>().Run();
        }
    }

    void MonNum()
    {
        if (stage < 3)
        {
            mon1.GetComponent<MonsterScript>().monnum = 1;
            mon2.GetComponent<MonsterScript>().monnum = 2;
            mon3.GetComponent<MonsterScript>().monnum = 3;
        }
        else
        {
            mon1.GetComponent<MonsterScript>().monnum = 1;
            mon2.GetComponent<MonsterScript>().monnum = 2;
        }
    }

    public void Fly()
    {
        fly.SetActive(true);
        flymode = true;

        float r1 = Mathf.Atan2(yf - y5, xf - x5) * Mathf.Rad2Deg;
        if(r1 < -30)
        {
            r1 = -30;
        }
        fly.transform.rotation = Quaternion.Euler(0, 0, r1);
    }

    public void Flyoff()
    {
        if(monnum2 == 1)
        {
            mon1.GetComponent<MonsterScript>().OnDamaged();
        }
        else if(monnum2 == 2)
        {
            mon2.GetComponent<MonsterScript>().OnDamaged();
        }
        else if (monnum2 == 3)
        {
            mon3.GetComponent<MonsterScript>().OnDamaged();
        }
        monnum2 = 0;

        fly.transform.position = new Vector2(x5, y5);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode = false;
        punch.GetComponent<PunchScript>().punchmode = 1;
        punch.GetComponent<PunchScript>().PunchMode();
        punch.GetComponent<PunchScript>().ScrollChange2();
    }

    public void Fly1()
    {
        fly.SetActive(true);
        flymode1 = true;

        float r1 = Mathf.Atan2(yf - y5, xf - x5) * Mathf.Rad2Deg;
        if (r1 < -30)
        {
            r1 = -30;
        }
        fly.transform.rotation = Quaternion.Euler(0, 0, r1);
    }

    public void Flyoff1()
    {
        boss.GetComponent<Stage1BossScript>().OnDamaged();

        fly.transform.position = new Vector2(x5, y5);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode1 = false;
        punch.GetComponent<PunchScript>().punchmode = 1;
        punch.GetComponent<PunchScript>().PunchMode();
        punch.GetComponent<PunchScript>().ScrollChange2();
    }

    public void BossHealthbarOn()
    {
        BH.SetActive(true);
        BHBB.SetActive(true);
    }
    public void BossHealthbarOff()
    {
        BH.SetActive(false);
        BHBB.SetActive(false);
    }

    public void Boss1Skill()
    {
        mon1.transform.position = new Vector2(boss.transform.position.x - 2, y1);
        mon2.transform.position = new Vector2(boss.transform.position.x + 2, y2);
        mon1.GetComponent<MonsterScript>().respawn2();
        mon2.GetComponent<MonsterScript>().respawn2();
        boss.GetComponent<Stage1BossScript>().skill1 = false;
    }

    public void StageEnding()
    {
        if(ending != null)
        {
            ending.GetComponent<endingscene>().stage = 1;
            ending.GetComponent<endingscene>().endingStart();
        }
    }

    void textoff()
    {
        text.SetActive(false);
    }
}