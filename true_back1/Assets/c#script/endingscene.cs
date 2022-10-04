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
    
    public void endingStart()
    {
        endingback = Resources.Load<GameObject>("Prefabs/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,-5.14f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("Prefabs/endingCha");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-7.17f), Quaternion.identity); //주인공이미지생성
        endingstar1 = Resources.Load<GameObject>("Prefabs/star1");
        Instantiate(endingstar1, new Vector3(-4.54f,1.12f, -7.27f), endingstar1.transform.rotation); // 별 생성
        endingstar2 = Resources.Load<GameObject>("Prefabs/star2");
        Instantiate(endingstar2, new Vector3(-0.01f,2.69f, -7.27f), Quaternion.identity);
        endingstar3 = Resources.Load<GameObject>("Prefabs/star3");
        Instantiate(endingstar3, new Vector3(4.54f,1.12f, -7.27f), endingstar3.transform.rotation);
    }
}
    /* 별 -- size는 크기, upsizetime은 지속시간
    float time = 0; 
    public float _size = 5;
    public float _upSizeTime =0.2f;
    */
/*
    Vector3 destination = new Vector3(-0.28f,-2.13f,-7.17f); // 주인공 도착지점

    public IEnumerator endingupdate()
    {
        Debug.Log((endingPlayer.transform.position - destination).magnitude );
        while((endingPlayer.transform.position - destination).magnitude > 0.01f ){
            Debug.Log("반복문되는중"); //여기 부분이 작동되지 않습니다!!
            endingPlayer.transform.position = Vector3.Lerp(endingPlayer.transform.position, destination, 0.001f); // 주인공 올라감
        
            /* 별 바운스
            if(time <= _upSizeTime)
            {
                endingstar1.transform.localScale = Vector3.one * (1 + _size * time);
            }
            else if (time <= _upSizeTime*2)
            {
                endingstar1.transform.localScale = Vector3.one * (2*_size * _upSizeTime + 1 - time * _size);
            }
            else
            {
                endingstar1.transform.localScale = Vector3.one;
            }
            time += Time.deltaTime;
        
            yield return null;
            *//*
        }
    }
/*
    public void resetAnim()
    {
        time = 0;
    }
    *//*
}
*/
