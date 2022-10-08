using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private int stage; //현재 단계 확인용 변수
    private bool stagemove; //단계 사이 이동 시간 확보용 변수

    public int remain; //단계별 남은 몬스터 수 확인용 변수

    public GameObject cul; //플레이어 머리 위 무기

    public GameObject Stage1Moster; //단계별 몬스터 소환용
    public GameObject Stage2Moster;
    public GameObject Stage3Moster;

    public GameObject punch;
    public GameObject canvas;
    public GameObject text;

    public GameObject NumScollview; //숫자
    public GameObject CalculScollview; //연산기호

    GameObject ForDestroy;

    public void Start() //게임 시작 초기화
    {
        NumScollview.SetActive(true);
        CalculScollview.SetActive(false);

        text.SetActive(false);

        stage = 1;
        stagemove =false;
        remain = 3;
    }

    void Update()
    {
        if(stage == 1 && stagemove == false) //1단계 시작
        {
            Debug.Log("1단계 시작");
            cul.SetActive(true);

            canvas.GetComponent<TextScript>().text.text = "Stage 1 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Stage1Moster, new Vector3(12 + i, 3, 0), Stage1Moster.transform.rotation);
            }
            stagemove = true;
        }

        if (stage == 1 && remain == 0) //1단계 종료
        {
            Debug.Log("1단계 클리어");
            cul.SetActive(false);

            canvas.GetComponent<TextScript>().text.text = "Stage 1 Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            GameObject.Find("Player").GetComponent<PlayerScript>().move = 1;
            Invoke("StageMove", 11f);

            remain = 3;
        }

        if (stage == 2 && stagemove == false) //2단계 시작
        {
            Debug.Log("2단계 시작");
            cul.SetActive(true);

            canvas.GetComponent<TextScript>().text.text = "Stage 2 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Stage2Moster, new Vector3(12 + i, 3, 0), Stage2Moster.transform.rotation);
            }
            stagemove = true;
        }

        if (stage == 2 && remain == 0) //2단계 종료
        {
            Debug.Log("2단계 클리어");
            cul.SetActive(false);

            canvas.GetComponent<TextScript>().text.text = "Stage 2 Clear!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            GameObject.Find("Player").GetComponent<PlayerScript>().move = 1;
            Invoke("StageMove", 11f);

            remain = 3;
        }

        if (stage == 3 && stagemove == false) //3단계 시작
        {
            Debug.Log("3단계 시작");
            cul.SetActive(true);

            canvas.GetComponent<TextScript>().text.text = "Stage 3 Start!";
            text.SetActive(true);
            Invoke("textoff", 2f);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Stage3Moster, new Vector3(12 + i, 3, 0), Stage3Moster.transform.rotation);
            }
            stagemove = true;
        }

        if (stage == 3 && remain == 0) //클리어
        {
            Debug.Log("클리어!");
            cul.SetActive(false);

            canvas.GetComponent<TextScript>().text.text = "Clear!";
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

    public void StageEnding()
    {
        var ending = GameObject.Find("ending").GetComponent<endingscene>();
        if(ending != null)
        {
            ending.endingStart();
        }
    }

    public void Clear() //클리어 함수
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Fail() //실패 함수
    {
        Debug.Log("Fail");

        canvas.GetComponent<TextScript>().text.text = "Fail...";
        text.SetActive(true);
        Invoke("textoff", 2f);

        Invoke("end", 2f);
    }

    void end()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void textoff()
    {
        text.SetActive(false);
    }
}