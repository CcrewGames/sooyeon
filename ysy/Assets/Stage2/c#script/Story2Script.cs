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
        sentences1.Add("�̹��� �α����ΰ�?");
        sentences1.Add("���� ���� ���� ���Ŀ��� ���� �Ʒ��� �ϳ��� �� �����µ�! �̹��� �޸��⿴�� ���̾�!!");
        sentences1.Add("�׷��� �������� ���� ��ư�� ������� �� �� �����ϰھ�.");
        sentences1.Add("����! ������!");
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
        sentences1_2.Add("�̹��� �ҷ� �� �����̱���. ���� �״�ξ�.");
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
        sentences2.Add("��ħ�� ����߱���... �� ������ ����... ������� ���ٴ� �� ��Ÿ�����..."); //�α���
        sentences2.Add("�α׽� ���Դϱ�?"); //Į
        sentences2.Add("(������⿣, �α׽ʰ� �޸� ����� �׶��� �� ������...)"); //Į
        sentences2.Add("������ �������� �밡���� ���Դϴ�. �׸��� �� ��ŵ� �� �밡�� ġ��� �� ���Դϴ�."); //Į
        sentences2.Add("��...! ���� ��Ÿ��� ����� �� 1:1618 Ȳ�ݺ� ���ſ� �� �´� ������̾��µ�... ���� �ƽ�����...!"); //�α���
        sentences2.Add("(�� ���� ���� ���� �ʴ� ��...)"); //Į
        sentences2.Add("��ŵ� �� �������� ������ �������ðھ��...?"); //�α���
        sentences2.Add("���ٹ��� �̿��� �� �ŷ¿� ǫ ������ ����ھ��...!"); //�α���
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
        sentences2_2.Add("�̤�..."); //Į
        sentences2_2.Add("������ ��!!!"); //�α���
        sentences2_2.Add("(�ݸ�...?)"); //Į
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
        sentences3.Add("���� �и� ���߽��ϴ�. ��ŵ� �밡�� ġ���� �� �Ŷ��."); //Į
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