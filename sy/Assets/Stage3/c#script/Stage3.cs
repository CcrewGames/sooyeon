//스테이지 3
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3 : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Resume;
    public bool pausemode;

    public int stage; //현재 단계 확인용 변수
    public bool stagemove; //단계 사이 이동 시간 확보용 변수
    public int fortime; //시간 흐르게 하기 위한 변수

    public int remain; //단계별 남은 몬스터 수 확인용 변수

    public GameObject canvas;
    //public GameObject text;

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
    float y3 = -1.2f;
    float y4 = -0.6f;

    public GameObject Cul;
    float x4 = 4.5f;
    float y4 = -2.5f;
    public GameObject CH;
    public GameObject CHBB;

    public GameObject punch;

    public GameObject ending;

    //칼 날라가기~
    public GameObject AttackBar1; //칼
    public GameObject AttackBar2; //큘
    GameObject fly;
    GameObject flyc;
    float xk = -6.5f; //칼
    float xc = 6.5f; //큘
    float yb = 2.8f;
    public float xf; //칼
    public float yf;
    public float xfc = -7; //큘
    public float yfc = -1.5f;
    float speed = 7.5f;
    bool flymode; //칼
    bool flymodec; //큘

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

        stage = 0;
        stagemove = true;
        remain = 0;

        monstermove = 0;
        
        monnum2 = 0;

        story = 0;

        fly = Instantiate(AttackBar1, new Vector2(xk, yb), transform.rotation);
        fly.SetActive(false);
        flyc = Instantiate(AttackBar2, new Vector2(xc, yb), transform.rotation);
        flyc.SetActive(false);
        flymode = false;
        flymodec = false;
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

        if (flymodec == true)
        {
            flyc.transform.position = Vector2.Lerp(flyc.transform.position, new Vector2(xfc, yfc), Time.deltaTime * speed);
        }
        if (flyc.transform.position.x >= xfc - 1f && flymodec == true)
        {
            Flyoffc();
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
            CulSkill();

            stagemove = true;
        }

        if (stage == 1 && remain == 0) //1단계 종료
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            GameObject.Find("Player").GetComponent<KalScript>().HealStop();
            GameObject.Find("Player").GetComponent<KalScript>().Run();

            Invoke("StageMove", 13f);

            remain = 1;
        }

        if (stage == 2 && stagemove == false) //2단계 시작
        {
            fortime = 1;
            punch.GetComponent<PunchScript>().ScrollChange2();

            punch.GetComponent<PunchScript>().punchmode = 1;
            punch.GetComponent<PunchScript>().PunchMode();
            
            stagemove = true;
        }

        if (stage == 2 && remain == 0) //클리어
        {
            fortime = 0;
            punch.GetComponent<PunchScript>().ScrollChange3();

            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            GameObject.Find("Player").GetComponent<PlayerScript>().HealStop();
            
            Invoke("StageMove", 5f);

            remain = 3; //얘는 남은 몬스터 수 확인용이 아니라 한 번만 실행되도록 하기 위함
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
        mon3.GetComponent<MonsterScript2>().monnum = 1;
        mon4.GetComponent<MonsterScript2>().monnum = 2;
    }

    public void Fly()
    {
        fly.SetActive(true);
        flymode = true;

        float r1 = Mathf.Atan2(yf - y5, xf - x5) * Mathf.Rad2Deg;
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
        monnum2 = 0;

        fly.transform.position = new Vector2(x5, y5);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode = false;
        punch.GetComponent<PunchScript>().punchmode = 1;
        punch.GetComponent<PunchScript>().PunchMode();
        punch.GetComponent<PunchScript>().ScrollChange2();
    }

    public void Flyc()
    {
        flyc.SetActive(true);
        flymodec = true;

        float r1 = Mathf.Atan2(yfc - yc, xfc - xc) * Mathf.Rad2Deg;
        if (r1 < -30)
        {
            r1 = -30;
        }
        flyc.transform.rotation = Quaternion.Euler(0, 0, r1);
    }

    public void Flyoffc()
    {
        //플레이어 맞는 코드

        fly.transform.position = new Vector2(x5, y5);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode1 = false;
        punch.GetComponent<PunchScript>().punchmode = 1;
        punch.GetComponent<PunchScript>().PunchMode();
        punch.GetComponent<PunchScript>().ScrollChange2();
    }

    public void CulHealthbarOn()
    {
        CH.SetActive(true);
        CHBB.SetActive(true);
    }
    public void CulHealthbarOff()
    {
        CH.SetActive(false);
        CHBB.SetActive(false);
    }

    public void CulSkill()
    {
        mon1.transform.position = new Vector2(Cul.transform.position.x - 2, y1);
        mon2.transform.position = new Vector2(Cul.transform.position.x - 1, y2);
        mon3.transform.position = new Vector2(Cul.transform.position.x + 1, y3);
        mon4.transform.position = new Vector2(Cul.transform.position.x + 2, y4);
        mon1.GetComponent<MonsterScript>().respawn2();
        mon2.GetComponent<MonsterScript>().respawn2();
        mon3.GetComponent<MonsterScript2>().respawn2();
        mon4.GetComponent<MonsterScript2>().respawn2();
    }

    public void StageEnding()
    {
        if (ending != null)
        {
            ending.GetComponent<endingscene>().stage = 3;
            ending.GetComponent<endingscene>().endingStart();
        }
    }
}