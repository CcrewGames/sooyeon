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
        sentences1.Add("���� �����߱�!");
        sentences1.Add("�������� ���� ��ư�� ������� �� �� �����ϰھ�.");
        sentences1.Add("����! ������!");
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
        sentences2.Add("��ħ�� ����߱���... �� ������ ����... ������� ���ٴ� �� ��Ÿ�����..."); //�α���
        sentences2.Add("�α׽� ���Դϱ�?"); //Į
        sentences2.Add("������ �������� �밡���� ���Դϴ�. �׸��� ��ŵ� �� �� �밡�� ġ��� �� ���Դϴ�!"); //Į
        sentences2.Add("��...! ���� ��Ÿ��� ����� �� 1:1618 Ȳ�ݺ� ���ſ� �� �´� ������̾��µ�... ���� �ƽ�����...!"); //�α���
        sentences2.Add("(�� ���� ���� ���� �ʴ� ��...)"); //Į
        sentences2.Add("��ŵ� �� �������� ������ �������ðھ��...?"); //�α���
        sentences2.Add("���ٹ��� �̿��� �� �ŷ¿� ǫ ������ ����ھ��...!"); //�α���
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