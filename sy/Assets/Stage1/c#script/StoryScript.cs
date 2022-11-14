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
        sentences1.Add("���� �����߱�.");
        sentences1.Add("���� �̷� �߿� ���� �Ǵ���� �����ִ� ���̾�?");
        sentences1.Add("���� ���� ȥ���� ����� �ھ�!");
        //sentences1.Add("(��... �߿�.)");
        //sentences1.Add("���Ⱑ ���θ� ��� �������󱸳�.");
        //sentences1.Add("�����ߴ� �ͺ��� �ξ� ���.");
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
        sentences2.Add("�̷�! ���� ������� �� �����ٴ�! �츮 ������ �� ó���ع��� ���ΰ�?!"); //�α׽�
        sentences2.Add("�׷����ϴ�! ��ü ��ȭ�Ӵ� ���������� ���������� �� ������ �̴ϱ�?"); //Į
        sentences2.Add("��ŵ� ������ �ֹε��� ����ް� �ֽ��ϴ�."); //Į
        sentences2.Add("�츰 �� ������ ������ ����Ų �Ŷ��!"); //�α׽�
        sentences2.Add("��ε� ����������� ���� ���� ���� �� ����... �ڳ� �� ������ �ų��� ������ �� �ְڳ�?"); //�α׽�
        sentences2.Add("(�������� �ƴϱ�...)"); //Į
        sentences2.Add("�ڳ� �츮�� ������ ������ ������ �� ����!"); //�α׽�
        sentences2.Add("1:2, 3:2 ���� ���� �̻��� ȭ�� ���� ���� ���Գ�!"); //�α׽�
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