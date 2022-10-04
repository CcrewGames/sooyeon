/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using 지시문 추가

public class swipe_menu : MonoBehaviour//모든 유니티 컴포넌트 스크립트는 MonoBehaviour 를 상속
{
    public GameObject scrollbar; // 어디에서든 접근 가능한/ 게임오브젝트 컴포넌트/scrollbar 변수-현재 부착된 오브젝트를 가르킴
    float scroll_pos = 0; // scroll_pos라는 실수형 변수
    float[] pos; // 실수형 배열 pos

    void Start(){   
    }//시작할 때 실행하는 함수

    void Update()//프레임마다 실행하는 함수
    {
        pos = new float[transform.childCount]; //transform.childCount 으로 자식의 개수를 불러 오기
        float distance 
        distance = 1f / (pos.Length -1f); // f 는 float/.Length는 배열 pos의 개수를 셈
        for (int i = 0; i < pos.Length,i++){// 배열 pos 에다가 길이를 놓음
        pos [i] = distance * i;
        } 
        if (Input.GetMouseButton(0)){ //마우스 버튼 입력 처리/(0) : 마우스 왼쪽 버튼 의미
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value; //scroll_pos변수에 
            //스크롤바 값 가져 오기 -> 게임오브젝트명.GetComponent<Scrollbar>().value
        }else{
            for (int i = 0; i < pos.Length; i++){
                if (scroll_pos < pos[i] + (distance /2) && scroll_pos > pos[i] - (distance /2)){  //으아악
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp (scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }// 선형보간법 Mathf.Lerp 으로 부드러운 스크롤링 구현
            }
        }

        for (int i = 0; i < pos.Length; i++){
            if (scroll_pos< pos [i] + (distance /2) && scroll_pos > pos[i] - (distance /2)){
                transform.GetChild (i).localScale = Vector2.Lerp (transform.GetChild(i).localScale, new Vector2(1f,1f),0.1f);
                //transform.localScale -> 게임오브젝트의 부모 기준 상대적인 크기
                for (int a = 0; a < pos.Length; a++){
                    if (a != i) {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f,0.8f), 0.1f);
                        //transform.GetChild(a) -> 번호 순으로 자식 GameObject를 찾는 방법  
                        //자식 오브젝트의 크기
                        //Vector2.Lerp 이것도 보간법

                    }
                }
            }
        }
    }
}
*/

