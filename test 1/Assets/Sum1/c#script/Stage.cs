using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private int stage;
    private bool stagemove;
    public int remain; //남은 몬스터 수

    public GameObject punch;
    public GameObject cul;

    GameObject ForDestroy;

    public GameObject NumScollview; //숫자
    public GameObject CalculScollview; //연산기호

    public GameObject Stage1Moster;
    public GameObject Stage2Moster;
    public GameObject Stage3Moster;

    public void Start()
    {
        NumScollview.SetActive(true);
        CalculScollview.SetActive(false);
        punch.GetComponent<PunchScript>().re();

        stage = 1;
        stagemove =false;
        remain = 3;
    }

    void Update()
    {
        if(stage == 1 && stagemove == false) //1단계 시작
        {
            Debug.Log("Stage 1 Start");
            cul.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Stage1Moster, new Vector3(12 + i, 3, 0), Stage1Moster.transform.rotation);
            }
            stagemove = true;
        }

        if (stage == 1 && remain == 0) //1단계 종료
        {
            Debug.Log("Stage 1 Clear");

            cul.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerScript>().move = 1;
            Invoke("StageMove", 10f);

            remain = 3;
        }

        if (stage == 2 && stagemove == false) //2단계 시작
        {
            Debug.Log("Stage 2 Start");
            cul.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Stage2Moster, new Vector3(12 + i, 3, 0), Stage2Moster.transform.rotation);
            }
            stagemove = true;
        }

        if (stage == 2 && remain == 0) //2단계 종료
        {
            Debug.Log("Stage 2 Clear");

            cul.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerScript>().move = 1;
            Invoke("StageMove", 10f);

            remain = 3;
        }

        if (stage == 3 && stagemove == false) //3단계 시작
        {
            Debug.Log("Stage 3 Start");
            cul.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Stage3Moster, new Vector3(12 + i, 3, 0), Stage3Moster.transform.rotation);
            }
            stagemove = true;
        }

        if (stage == 3 && remain == 0) //클리어
        {
            Debug.Log("All Clear!");
            cul.SetActive(false);
            Invoke("StageEnding", 2);
            Invoke("Clear", 5);

            remain = 3; //한 번만 되도록
        }
    }

    public void StageMove()
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

    public void Clear()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Fail()
    {
        Debug.Log("Fail");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}