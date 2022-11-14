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
    public List<string> sentences1_2;
    public List<string> sentences2;
    public List<string> sentences2_2;
    public List<string> sentences3;
    public bool clickNextButton = false;

    int size, i;

    private GameObject target; //���콺 Ŭ�� Ȯ�ο� ����

    void CastRay() //���콺 Ŭ�� Ȯ�ο� �Լ�
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }

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
            i++;
            if (i == size)
            {
                StoryOff();
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 1)
            {
                storytext.text = sentences1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 1.5f)
            {
                storytext.text = sentences1_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 2)
            {
                if (i == 4 || i == 5 || i == 8 || i == 9)
                {
                    Storylog10();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 2.5f)
            {
                if (i == 2)
                {
                    Storylog10();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 3)
            {
                if (i == 2 || i == 3)
                {
                    Storylog10();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences3[i];
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
        sentences1.Add("����. �׻� ���� ����� �ž�?!");
        sentences1.Add("�׳����� ���� ���� ���������� ������ ���� ������...");
        sentences1.Add("�̷� �� �˾����� ���� �Ʒ� �� �������� �� ��!");
        sentences1.Add("�� ���ʿ��� ���� ���� ����� ��������.");
        sentences1.Add("�ѹ� ���ư�����.");
        size = sentences1.Count;

        i = 0;
        storytext.text = sentences1[i];
    }
    public void Story1_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 1.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1_2 = new List<string>();
        sentences1_2.Add("�̷�, ó�� ���� ���������ݾ�!");
        sentences1_2.Add("���������� ŧ�� ���ϵ��ΰ�����. ���� ���� ȥ���� ������!");
        size = sentences1_2.Count;

        i = 0;
        storytext.text = sentences1_2[i];
    }

    public void Story2On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 2;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //0, 4, 5, 8, 9
        sentences2.Add("�̷�! ���� ������� �� �����ٴ�! �츮 ������ �� ó���ع��� ���ΰ�?!"); //�α׽�
        sentences2.Add("(���� ����� �����߱�.)"); //Į
        sentences2.Add("�׷����ϴ�. ��ü ��ȭ�Ӵ� �� ���� ������ �� ������ �̴ϱ�?"); //Į
        sentences2.Add("��ŵ� ������ ������ �ֹε��� ����ް� �ֽ��ϴ�!"); //Į
        sentences2.Add("�۽�? ���� �츰 �� ������ ������ ����Ų �Ŷ��!"); //�α׽�
        sentences2.Add("��ε� ����������� ���� ���� ���� �� ����... �� �ų��� ������ �� �ְڳ�?"); //�α׽�
        sentences2.Add("(�������� �ƴ��ݾ�...)"); //Į
        sentences2.Add("Į�� ���� ������ �� �� ��ȸ�ϰ� �� ���Դϴ�."); //Į
        sentences2.Add("���� �� ���� ����ϴٴ�! �ڳ� ���� �츮�� ������ ������ ������ �� ����!"); //�α׽�
        sentences2.Add("���� 1:2, 3:2 ���� ���� �̻��� ȭ�� ���� ���� ���Գ�!"); //�α׽�
        size = sentences2.Count;

        Storylog10();
        i = 0;
        storytext.text = sentences2[i];
    }
    public void Story2_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 2.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2_2 = new List<string>();
        //2
        sentences2_2.Add("�� �̻��� ������ ���߰ڴ� ����ϼ���!"); //Į
        sentences2_2.Add("�׷� ���� �� �̻� ����� �������� ���� ���Դϴ�!"); //Į
        sentences2_2.Add("��Ҹ��� ����ġ��!"); //�α׽�
        size = sentences2_2.Count;

        Storykal();
        i = 0;
        storytext.text = sentences2_2[i];
    }

    public void Story3On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 3f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3 = new List<string>();
        //0, 2, 3
        sentences3.Add("����..."); //�α׽�
        sentences3.Add("...��ü ������ ����� �̷��Ա��� ���� �̴ϱ�."); //Į
        sentences3.Add("�����ݾ�. �� ���� ����� ������ �� ���ٰ�..."); //�α׽�
        sentences3.Add("������� ��. ���� �׾ �� �ο��� ��ӵɰɼ�..."); //�α׽�
        size = sentences3.Count;

        Storylog10();
        i = 0;
        storytext.text = sentences3[i];
    }

    void Storykal()
    {
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
    }
    void Storylog10()
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

        clickNextButton = false;
    }
}