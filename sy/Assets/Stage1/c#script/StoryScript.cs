using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public GameObject background, playerimage, bossimage, textbox, nextbutton, canvas;
    GameObject background1, playerimage1, bossimage1, textbox1, nextbutton1;
    
    public Text storytext;

    public List<string> sentences1;
    public List<string> sentences2;
    public bool clickNextButton = false;

    int size, i;

    void Start()
    {
        background1 = Instantiate(background, background.transform.position, transform.rotation);
        playerimage1 = Instantiate(playerimage, playerimage.transform.position, transform.rotation);
        bossimage1 = Instantiate(bossimage, bossimage.transform.position, transform.rotation);
        textbox1 = Instantiate(textbox, textbox.transform.position, transform.rotation);
        nextbutton1 = Instantiate(nextbutton, nextbutton.transform.position, transform.rotation);

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);
    }

    void Update()
    {
        if (clickNextButton == true && GameObject.Find("Stage").GetComponent<Stage>().story != 0)
        {
            if(i + 1 == size)
            {
                StoryOff();
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 1)
            {
                i++;
                storytext.text = sentences1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 2)
            {
                i++;
                if (i == 3 || i == 4 || i == 6 || i == 7)
                {
                    Story2log10();
                }
                else
                {
                    Story2kal();
                }
                storytext.text = sentences2[i];
                clickNextButton = false;
            }
        }
    }

    public void Story1On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 1;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1 = new List<string>();
        sentences1.Add("드디어 도착했군.");
        sentences1.Add("정말 이런 추운 곳에 악당들이 숨어있단 말이야?");
        sentences1.Add("내가 전부 혼쭐을 내줘야 겠어!");
        //sentences1.Add("(으... 추워.)");
        //sentences1.Add("여기가 말로만 듣던 얼음나라구나.");
        //sentences1.Add("생각했던 것보다 훨씬 춥네.");
        size = sentences1.Count;
        i = 0;
        storytext.text = sentences1[0];
    }

    public void Story2On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 2;

        Story2log10();
        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //0, 3, 4, 6, 7
        sentences2.Add("이런! 벌써 여기까지 와 버리다니! 우리 기사들을 다 처리해버린 것인가?!"); //로그십
        sentences2.Add("그렇습니다! 대체 평화롭던 덧셈뺄셈의 얼음마을을 왜 공격한 겁니까?"); //칼
        sentences2.Add("당신들 때문에 주민들이 고통받고 있습니다."); //칼
        sentences2.Add("우린 이 마을에 혁명을 일으킨 거라네!"); //로그십
        sentences2.Add("모두들 미적미적대는 꼴은 정말 봐줄 수 없어... 자넨 내 적분의 신념을 이해할 수 있겠나?"); //로그십
        sentences2.Add("(제정신이 아니군...)"); //칼
        sentences2.Add("자넨 우리의 위대한 긍지를 이해할 수 없어!"); //로그십
        sentences2.Add("1:2, 3:2 정수 비의 이상적 화음 공격 맛을 보게나!"); //로그십
        size = sentences2.Count;
        i = 0;
        storytext.text = sentences2[0];
    }
    public void Story2kal()
    {
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
    }
    public void Story2log10()
    {
        playerimage1.SetActive(false);
        bossimage1.SetActive(true);
    }

    public void StoryOff()
    {
        GameObject.Find("Stage").GetComponent<Stage>().ResumeMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 0;

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);
    }
}