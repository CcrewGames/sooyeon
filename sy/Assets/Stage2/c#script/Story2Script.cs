using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story2Script : MonoBehaviour
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
        if (clickNextButton == true && GameObject.Find("Stage").GetComponent<Stage2>().story != 0)
        {
            if(i + 1 == size)
            {
                StoryOff();
            }
            else if (GameObject.Find("Stage").GetComponent<Stage2>().story == 1)
            {
                i++;
                storytext.text = sentences1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage2>().story == 2)
            {
                i++;
                if (i == 3 || i == 5 || i == 6)
                {
                    Story2log1();
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
        GameObject.Find("Stage").GetComponent<Stage2>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage2>().story = 1;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1 = new List<string>();
        sentences1.Add("드디어 도착했군!");
        sentences1.Add("이전보다 많은 버튼을 얻었으니 좀 더 수월하겠어.");
        sentences1.Add("가자! 앞으로!");
        size = sentences1.Count;
        i = 0;
        storytext.text = sentences1[0];
    }

    public void Story2On()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage2>().story = 2;

        Story2log1();
        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //0, 3, 5, 6
        sentences2.Add("마침내 대면했군요... 내 형제의 원수... 여기까지 오다니 참 안타까워요..."); //로그일
        sentences2.Add("로그십 말입니까?"); //칼
        sentences2.Add("세상을 어지럽힌 대가였을 뿐입니다. 그리고 당신도 곧 그 대가를 치루게 될 것입니다!"); //칼
        sentences2.Add("아...! 그의 피타고라스 음계는 내 1:1618 황금비 몸매에 딱 맞는 배경음이었는데... 정말 아쉬워요...!"); //로그일
        sentences2.Add("(내 말을 전혀 듣지 않는 군...)"); //칼
        sentences2.Add("당신도 제 수학적인 예술을 느껴보시겠어요...?"); //로그일
        sentences2.Add("원근법을 이용한 제 매력에 푹 빠지게 만들겠어요...!"); //로그일
        size = sentences2.Count;
        i = 0;
        storytext.text = sentences2[0];
    }
    public void Story2kal()
    {
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
    }
    public void Story2log1()
    {
        playerimage1.SetActive(false);
        bossimage1.SetActive(true);
    }

    public void StoryOff()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().ResumeMode();
        GameObject.Find("Stage").GetComponent<Stage2>().story = 0;

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);
    }
}