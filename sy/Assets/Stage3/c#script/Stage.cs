using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    public int stage; //현재 단계 확인용 변수
    public bool stagemove; //단계 사이 이동 시간 확보용 변수
    public int fortime; //시간 흐르게 하기 위한 변수

    public int remain; //단계별 남은 몬스터 수 확인용 변수
    
    public GameObject canvas;
    public GameObject text;

    public GameObject monster;
    public int monstermove;
    GameObject mon1;
    GameObject mon2;
    GameObject mon3;
    float x1 = 15f;
    float x2 = 18f;
    float x3 = 21f;
    float y1 = -0.8f;
    float y2 = -1.6f;
    float y3 = -1.2f;
    float z1 = -2f;
    float z2 = -3f;
    float z3 = -4f;

    public GameObject BossMonster;
    GameObject boss;
    float x4 = 14f;
    float y4 = 0f;
    float z4 = -1f;

    public GameObject punch;

    public GameObject ending;
    public GameObject Zero;
    public GameObject Timeout;
    public GameObject timebox;

    //칼 날라가기~
    public GameObject AttackBar;
    GameObject fly;
    float x5 = -6.5f;
    float y5 = 2.8f;
    float z5 = 0f;
    public float xf;
    public float yf;
    float speed = 15f;
    bool flymode;

    public bool bossdie;

    GameObject ForDestroy;

    public void Start() //게임 시작 초기화
    {
        Zero.SetActive(false);
        Timeout.SetActive(false);
        timebox.SetActive(false);

        text.SetActive(false);

        stage = 2;
        //stage = 0;
        stagemove = true;
        remain = 0;

        monstermove = 0;
        bossdie = false;

        fly = Instantiate(AttackBar, new Vector3(x5, y5, -1), transform.rotation);

        fly.SetActive(false);

        flymode = false;
    }

    void Update()
    {
        if (stage == 0 && remain == 0) //1단계 준비
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            GameObject.Find("Player").GetComponent<PlayerScript>().HealStop();

            mon1 = Instantiate(monster, new Vector3(x1, y1, z1), transform.rotation);
            mon2 = Instantiate(monster, new Vector3(x2, y2, z2), transform.rotation);
            mon3 = Instantiate(monster, new Vector3(x3, y3, z3), transform.rotation);
            mon1.SetActive(true);
            mon2.SetActive(true);
            mon3.SetActive(true);

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

            mon1 = Instantiate(monster, new Vector3(x1, y1, z1), transform.rotation);
            mon2 = Instantiate(monster, new Vector3(x2, y2, z2), transform.rotation);
            mon3 = Instantiate(monster, new Vector3(x3, y3, z3), transform.rotation);
            mon1.SetActive(true);
            mon2.SetActive(true);
            mon3.SetActive(true);

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

            mon1 = Instantiate(monster, new Vector3(x1, y1, z1), transform.rotation);
            mon2 = Instantiate(monster, new Vector3(x2, y2, z2), transform.rotation);
            mon1.SetActive(true);
            mon2.SetActive(true);

            boss = Instantiate(BossMonster, new Vector3(x4, y4, z4), transform.rotation);

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
            Invoke("StageMove", 4f);

            remain = 3; //얘는 남은 몬스터 수 확인용이 아니라 한 번만 실행되도록 하기 위함
        }

        if (stage == 4 && stagemove == false) //클리어
        {
            StageEnding();
            Invoke("End", 3f);

            stagemove = true;
        }

        if (flymode == true)
        {
            fly.transform.position = Vector3.MoveTowards(fly.transform.position, new Vector3(xf, yf, -1), Time.deltaTime * speed);
        }

        if (fly.transform.position.x > xf - 0.3)
        {
            Flyoff();
        }
    }

    void StageMove() //단계 사이 이동 시간 확보용 함수
    {
        stage++;
        stagemove = false;
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

    public void Fly()
    {
        fly.SetActive(true);
        flymode = true;

        float r1 = Mathf.Atan(yf - y5 / xf - x5); //*Mathf.Rad2Deg
        Debug.Log(r1);
        fly.transform.Rotate(0, 0, r1 - 5);
    }

    public void Flyoff()
    {
        fly.transform.position = new Vector3(x5, y5, z5);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode = false;
        punch.GetComponent<PunchScript>().punchmode = 1;
        punch.GetComponent<PunchScript>().PunchMode();
        punch.GetComponent<PunchScript>().ScrollChange2();
    }

    public void Boss1Skill()
    {
        mon1.transform.position = new Vector3(boss.transform.position.x - 2, y1, z1);
        mon2.transform.position = new Vector3(boss.transform.position.x + 2, y2, z2);
        mon1.GetComponent<MonsterScript>().respawn2();
        mon2.GetComponent<MonsterScript>().respawn2();
        boss.GetComponent<Stage1BossScript>().skill1 = false;
    }

    public void StageEnding()
    {
        if(ending != null)
        {
            ending.GetComponent<endingscene>().endingStart();
        }
    }

    void textoff()
    {
        text.SetActive(false);
    }

    public void End() //클리어 함수
    {
        //다른 씬으로 넘어가도록 해야 됨
    }

    public void Fail() //실패 함수
    {
        Invoke("End", 3f);
    }
}