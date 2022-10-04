using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stage = 1;
    public int[] clear = new int[3];
    public int remain = 3;
    public GameObject punch;

    GameObject ForDestroy;

    void Start()
    {
        punch.GetComponent<PunchScript>().re();
        clear[0] = 0;
        clear[1] = 0;
        clear[2] = 0;
    }

    void Update()
    {
        if(stage == 1 && clear[0] == 0) //스테이지1 시작
        {
            clear[stage - 1] = 1;
            Debug.Log("Stage 1 Start");
            Stage1Start();
        }

        if (stage == 1 && remain == 0) //스테이지1 종료
        {
            Debug.Log("Stage 1 Clear");
            remain = 3;
            GameObject.Find("Player").GetComponent<PlayerScript>().Inv1();
            GameObject.Find("stage").GetComponent<Animation>().Play("icebug");
        }

        if (stage == 2 && clear[1] == 0) //스테이지2 시작
        {
            clear[stage - 1] = 1;
            Debug.Log("Stage 2 Start");
            Stage2Start();
        }

        if (stage == 2 && remain == 0) //스테이지2 종료
        {
            Debug.Log("Stage 2 Clear");
            remain = 3;
            GameObject.Find("Player").GetComponent<PlayerScript>().Inv1();
            GameObject.Find("stage").GetComponent<Animation>().Play("icebug");
             
        }

        if (stage == 3 && clear[2] == 0) //스테이지3 시작
        {
            clear[stage - 1] = 1;
            Debug.Log("Stage 3 Start");
            Stage3Start();
        }

        if (stage == 3 && remain == 0) //클리어
        {
            Debug.Log("All Clear!");
            remain = 3;
            Invoke("StageEnding", 2);
            Invoke("Clear", 5);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            punch.GetComponent<PunchScript>().re();
        }
    }

    public void Stage1Start()
    {
        GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>().Stage1Spawn();
    }

    public void Stage2Start()
    {
        GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>().Stage2Spawn();
    }

    public void Stage3Start()
    {
        GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>().Stage3Spawn();
    }

    public void StageEnding()
    {
        var ending = GameObject.Find("ending").GetComponent<endingscene>();
        if(ending != null)
        {
            ending.endingStart();
            //StartCoroutine(ending.endingupdate());
        }
        //GameObject.Find("ending").GetComponent<endingscene>().endingStart();
        //GameObject.Find("ending").GetComponent<endingscene>().endingupdate();
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

    public void Remain()
    {
        remain -= 1;
    }

    public void StageMove()
    {
        stage += 1;
    }
}