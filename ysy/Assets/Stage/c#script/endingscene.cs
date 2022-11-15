// 스테이지의 엔딩씬. 별/플레이어 불러오기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingscene : MonoBehaviour
{   
    private GameObject endingback, endingPlayer, endingstar1, endingstar2, endingstar3, endingfailstar2, endingfailstar3;
    public GameObject Zero, canvas, Timeover, TimeCount, TimeEndingbox, Power;

    public GameObject a, b, c, d, e, f, g, h, I;

    float time;
    public int stage;

    //시간 불러오기 

    public void endingStart()
    {
        if (stage == 1)
        {
            time = TimeCount.GetComponent<Timecount>().countdownSeconds;
        }
        else if (stage == 2)
        {
            time = TimeCount.GetComponent<Timecount2>().countdownSeconds;
        }
        else if (stage == 3)
        {
            time = TimeCount.GetComponent<Timecount3>().countdownSeconds;
        }

        if ( 30 >= time && time > 0){//별 1개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-4.54f,1.12f, -5f), endingstar1.transform.rotation); // 별 생성
            //빈 2.3번째 별 
            endingfailstar2 = Resources.Load<GameObject>("ending/realendingfailstar2");
            Instantiate(endingfailstar2, new Vector3(0,3, -5f),endingfailstar2.transform.rotation);
            endingfailstar3 = Resources.Load<GameObject>("ending/realendingfailstar3");
            Instantiate(endingfailstar3, new Vector3(5,1.5f, -5f), endingfailstar3.transform.rotation);
        }
        else if (60 >= time && time > 30){//별 2개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-4.54f,1.12f, -5f), endingstar1.transform.rotation); // 별 생성
            endingstar2 = Resources.Load<GameObject>("ending/realendingstar2");
            Instantiate(endingstar2, new Vector3(0,3, -5f), Quaternion.identity);
            //빈 3번째 별 추가하기
            endingfailstar3 = Resources.Load<GameObject>("ending/realendingfailstar3");
            Instantiate(endingfailstar3, new Vector3(5,1.5f, -5f), endingfailstar3.transform.rotation);

        }
        else{//별 3개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-5,1.5f, -5f), endingstar1.transform.rotation); // 별 생성
            endingstar2 = Resources.Load<GameObject>("ending/realendingstar2");
            Instantiate(endingstar2, new Vector3(0,3, -5f), Quaternion.identity);
            endingstar3 = Resources.Load<GameObject>("ending/realendingstar3");
            Instantiate(endingstar3, new Vector3(5,1.5f, -5f), endingstar3.transform.rotation);
        }
    }
    public void Stagetimeout()
    {
        endingback = Resources.Load<GameObject>("ending/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("ending/timeendingplayer1");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
        canvas.GetComponent<TextScript2>().endingtext1.fontSize = 1.5f;
        canvas.GetComponent<TextScript2>().endingtext2.fontSize = 1.5f;

        Instantiate(TimeEndingbox, new Vector3(3.75f, -0.3f, -4f), Quaternion.identity);

        TimeCount.SetActive(false);  
        Power.SetActive(false);

        a.SetActive(false); b.SetActive(false); c.SetActive(false); d.SetActive(false); e.SetActive(false); f.SetActive(false); g.SetActive(false); h.SetActive(false); I.SetActive(false);

        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText(){
        while (true) {
            Zero.SetActive(false);    
            yield return new WaitForSeconds (0.4f);
            Zero.SetActive(true);    
            yield return new WaitForSeconds (0.4f);
        }
    }  

    public void Playerpowerend(){
        endingback = Resources.Load<GameObject>("ending/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("ending/timeendingplayer1");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
        canvas.GetComponent<TextScript2>().endingtext1.text = "    Power";
        canvas.GetComponent<TextScript2>().endingtext2.text = "     0";
        canvas.GetComponent<TextScript2>().endingtext1.fontSize = 1.5f;
        canvas.GetComponent<TextScript2>().endingtext2.fontSize = 1.5f;

        Instantiate(TimeEndingbox, new Vector3(3.75f, -0.3f, -4f), Quaternion.identity);

        TimeCount.SetActive(false);
        Power.SetActive(false);

        a.SetActive(false); b.SetActive(false); c.SetActive(false); d.SetActive(false); e.SetActive(false); f.SetActive(false); g.SetActive(false); h.SetActive(false); I.SetActive(false);

        StartCoroutine(BlinkText());
    }
}
  
  