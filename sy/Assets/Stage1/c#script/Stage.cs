using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private int stage; //현재 단계 확인용 변수
    public bool stagemove; //단계 사이 이동 시간 확보용 변수
    public int fortime;

    public int remain; //단계별 남은 몬스터 수 확인용 변수
    
    public GameObject canvas;
    public GameObject text;

    public GameObject monster;
    public int monstermove;
    GameObject mon1;
    GameObject mon2;
    GameObject mon3;
    float x1 = 11f;
    float x2 = 15f;
    float x3 = 19f;
    float y1 = -0.8f;
    float y2 = -1.6f;
    float y3 = -1.2f;
    float z1 = -1.5f;
    float z2 = -1.5f;
    float z3 = -1.5f;

    public GameObject punch;

    public GameObject NumScollview; //숫자
    public GameObject CalculScollview; //연산기호

    public GameObject ending;
    public GameObject Zero;
    public GameObject Timeout;

    public GameObject timebox;

    GameObject ForDestroy;

    public void Start() //게임 시작 초기화
    {
        NumScollview.SetActive(true);
        CalculScollview.SetActive(false);
        Zero.SetActive(false);
        Timeout.SetActive(false);
        timebox.SetActive(false);

        text.SetActive(false);

        stage = 1;
        stagemove = false;
        remain = 3;

        monstermove = 0;

        mon1 = Instantiate(monster, new Vector3(7, y1, z1), transform.rotation);
        mon2 = Instantiate(monster, new Vector3(11, y2, z2), transform.rotation);
        mon3 = Instantiate(monster, new Vector3(15, y3, z3), transform.rotation);

        mon1.SetActive(true);
        mon2.SetActive(true);
        mon3.SetActive(true);
    }

    void Update()
    {
        if(stage == 1 && stagemove == false) //1단계 시작
        {
            fortime = 1;
            Debug.Log("1단계 시작");
            punch.GetComponent<PunchScript>().ScrollChange2();
            punch.GetComponent<PunchScript>().punchmode = 1;
            punch.GetComponent<PunchScript>().PunchMode();

            canvas.GetComponent<TextScript>().text.text = "Stage 1 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            stagemove = true;
        }

        if (stage == 1 && remain == 0) //1단계 종료
        {
            fortime = 0;
            Debug.Log("1단계 클리어");
            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            canvas.GetComponent<TextScript>().text.text = "Stage 1 Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            mon1.transform.position = new Vector2(x1, y1);
            mon2.transform.position = new Vector2(x2, y2);
            mon3.transform.position = new Vector2(x3, y3);
            mon1.SetActive(true);
            mon2.SetActive(true);
            mon3.SetActive(true);

            GameObject.Find("Player").GetComponent<PlayerScript>().move = 1;
            Invoke("StageMove", 11f);

            remain = 3;
        }

        if (stage == 2 && stagemove == false) //2단계 시작
        {
            fortime = 1;
            Debug.Log("2단계 시작");
            punch.GetComponent<PunchScript>().ScrollChange2();
            punch.GetComponent<PunchScript>().punchmode = 1;
            punch.GetComponent<PunchScript>().PunchMode();

            monstermove = 2;
            MonsterMove();
            GameObject.Find("Player").GetComponent<PlayerScript>().one = false;

            canvas.GetComponent<TextScript>().text.text = "Stage 2 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            stagemove = true;
        }

        if (stage == 2 && remain == 0) //2단계 종료
        {
            fortime = 0;
            Debug.Log("2단계 클리어");
            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            canvas.GetComponent<TextScript>().text.text = "Stage 2 Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            mon1.transform.position = new Vector2(x1, y1);
            mon2.transform.position = new Vector2(x2, y2);
            mon3.transform.position = new Vector2(x3, y3);
            mon1.SetActive(true);
            mon2.SetActive(true);
            mon3.SetActive(true);

            GameObject.Find("Player").GetComponent<PlayerScript>().move = 1;
            Invoke("StageMove", 11f);

            remain = 3;
        }

        if (stage == 3 && stagemove == false) //3단계 시작
        {
            fortime = 1;
            Debug.Log("3단계 시작");
            punch.GetComponent<PunchScript>().ScrollChange2();
            punch.GetComponent<PunchScript>().punchmode = 1;
            punch.GetComponent<PunchScript>().PunchMode();

            monstermove = 2;
            MonsterMove();
            GameObject.Find("Player").GetComponent<PlayerScript>().one = false;

            canvas.GetComponent<TextScript>().text.text = "Stage 3 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            stagemove = true;
        }

        if (stage == 3 && remain == 0) //클리어
        {
            fortime = 0;
            Debug.Log("클리어!");
            punch.GetComponent<PunchScript>().punchmode = 0;
            punch.GetComponent<PunchScript>().PunchMode();

            canvas.GetComponent<TextScript>().text.text = "All Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            Invoke("StageEnding", 2f);
            Invoke("Clear", 5f);

            remain = 3; //얘는 남은 몬스터 수 확인용이 아니라 한 번만 실행되도록 하기 위함
        }
    }

    void StageMove() //단계 사이 이동 시간 확보용 함수
    {
        stage++;
        stagemove = false;
    }

    public void MonsterMove() //단계 사이 이동 시간 확보용 함수
    {
        if (monstermove == 1)
        {
            mon1.GetComponent<MonsterScript>().xm = 7f;
            mon2.GetComponent<MonsterScript>().xm = 11f;
            mon3.GetComponent<MonsterScript>().xm = 15f;
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
    }

    public void StageEnding()
    {
        if(ending != null)
        {
            ending.GetComponent<endingscene>().endingStart();
        }
    }

    public void Clear() //클리어 함수
    {
        Application.Quit();
    }

    public void Fail() //실패 함수
    {
        Debug.Log("Fail");
        Invoke("end", 3f);
    } 

    void end()
    {
        Application.Quit();
    }

    void textoff()
    {
        text.SetActive(false);
    }
}