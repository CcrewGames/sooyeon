// 스테이지의 엔딩씬. 별/플레이어 불러오기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingscene : MonoBehaviour
{   
    private GameObject endingback;
    private GameObject endingPlayer;
    private GameObject endingstar1;
    private GameObject endingstar2;
    private GameObject endingstar3;
    private GameObject endingfailstar2;
    private GameObject endingfailstar3;

    //시간 불러오기 
    
    public void endingStart()
    {
        float time = GameObject.Find("Timecount").GetComponent<Timecount>().countdownSeconds;

        if ( 30 >= time && time > 0){//별 1개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-5.14f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-7.17f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-4.54f,1.12f, -7.27f), endingstar1.transform.rotation); // 별 생성
            //빈 2.3번째 별 
            endingfailstar2 = Resources.Load<GameObject>("ending/realendingfailstar2");
            Instantiate(endingfailstar2, new Vector3(0,3,-5),endingfailstar2.transform.rotation);
            endingfailstar3 = Resources.Load<GameObject>("ending/realendingfailstar3");
            Instantiate(endingfailstar3, new Vector3(5,1.5f, -5), endingfailstar3.transform.rotation);
        }
        else if (60 >= time && time > 30){//별 2개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-5.14f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-7.17f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-4.54f,1.12f, -7.27f), endingstar1.transform.rotation); // 별 생성
            endingstar2 = Resources.Load<GameObject>("ending/realendingstar2");
            Instantiate(endingstar2, new Vector3(0,3,-5), Quaternion.identity);
            //빈 3번째 별 추가하기
            endingfailstar3 = Resources.Load<GameObject>("ending/realendingfailstar3");
            Instantiate(endingfailstar3, new Vector3(5,1.5f, -5), endingfailstar3.transform.rotation);

        }
        else{//별 3개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-5.14f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-7.17f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-5,1.5f, -5), endingstar1.transform.rotation); // 별 생성
            endingstar2 = Resources.Load<GameObject>("ending/realendingstar2");
            Instantiate(endingstar2, new Vector3(0,3,-5), Quaternion.identity);
            endingstar3 = Resources.Load<GameObject>("ending/realendingstar3");
            Instantiate(endingstar3, new Vector3(5,1.5f, -5), endingstar3.transform.rotation);
        }
    }
}
  
  