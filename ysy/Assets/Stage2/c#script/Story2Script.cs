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
    public List<string> sentences1_2;
    public List<string> sentences2;
    public List<string> sentences2_2;
    public List<string> sentences3;
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
            i++;
            if (i == size)
            {
                StoryOff();
            }
            else if (GameObject.Find("Stage").GetComponent<Stage2>().story == 1)
            {
                storytext.text = sentences1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage2>().story == 1.5f)
            {
                storytext.text = sentences1_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage2>().story == 2)
            {
                if (i == 4 || i == 6 || i == 7)
                {
                    Storylog1();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage2>().story == 2.5f)
            {
                if (i == 1)
                {
                    Storylog1();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage2>().story == 3)
            {
                storytext.text = sentences3[i];
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
        sentences1.Add("이번엔 로그일인가?");
        sentences1.Add("저번 얼음 마을 이후에는 점프 훈련을 하나도 안 빠졌는데! 이번엔 달리기였을 줄이야!!");
        sentences1.Add("그래도 이전보다 많은 버튼을 얻었으니 좀 더 수월하겠어.");
        sentences1.Add("가자! 앞으로!");
        size = sentences1.Count;

        i = 0;
        storytext.text = sentences1[i];
    }
    public void Story1_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage2>().story = 1.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1_2 = new List<string>();
        sentences1_2.Add("이번엔 불로 된 괴물이구나. 예상 그대로야.");
        size = sentences1_2.Count;

        i = 0;
        storytext.text = sentences1_2[i];
    }

    public void Story2On()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage2>().story = 2;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //0, 4, 6, 7
        sentences2.Add("마침내 대면했군요... 내 형제의 원수... 여기까지 오다니 참 안타까워요..."); //로그일
        sentences2.Add("로그십 말입니까?"); //칼
        sentences2.Add("(형제라기엔, 로그십과 달리 상당히 뚱뚱한 것 같은데...)"); //칼
        sentences2.Add("세상을 어지럽힌 대가였을 뿐입니다. 그리고 곧 당신도 그 대가를 치루게 될 것입니다."); //칼
        sentences2.Add("아...! 그의 피타고라스 음계는 내 1:1618 황금비 몸매에 딱 맞는 배경음이었는데... 정말 아쉬워요...!"); //로그일
        sentences2.Add("(내 말을 전혀 듣지 않는 군...)"); //칼
        sentences2.Add("당신도 제 수학적인 예술을 느껴보시겠어요...?"); //로그일
        sentences2.Add("원근법을 이용한 제 매력에 푹 빠지게 만들겠어요...!"); //로그일
        size = sentences2.Count;

        Storylog1();
        i = 0;
        storytext.text = sentences2[i];
    }
    public void Story2_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage2>().story = 2.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //1
        sentences2_2.Add("이ㅈ..."); //칼
        sentences2_2.Add("조용히 해!!!"); //로그일
        sentences2_2.Add("(반말...?)"); //칼
        size = sentences2_2.Count;

        Storykal();
        i = 0;
        storytext.text = sentences2_2[i];
    }

    public void Story3On()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage2>().story = 3;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3 = new List<string>();
        sentences3.Add("저는 분명 말했습니다. 당신도 대가를 치르게 될 거라고."); //칼
        size = sentences3.Count;

        Storykal();
        i = 0;
        storytext.text = sentences3[i];
    }

    void Storykal()
    {
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
    }
    void Storylog1()
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

        clickNextButton = false;
    }
}