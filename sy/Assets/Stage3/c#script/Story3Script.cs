using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story3Script : MonoBehaviour
{
    public GameObject background, playerimage, bossimage, textbox, nextbutton, canvas;
    GameObject background1, playerimage1, bossimage1, textbox1, nextbutton1;

    public Text storytext;

    public List<string> sentences1;
    public List<string> sentences2;
    public List<string> sentences2_2;
    public List<string> sentences3;
    public List<string> sentences3_2;
    public List<string> sentences4;
    public List<string> sentences4_2;
    public List<string> sentences5;
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
        if (clickNextButton == true && GameObject.Find("Stage").GetComponent<Stage3>().story != 0)
        {
            i++;
            if (i == size)
            {
                StoryOff();
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 1)
            {
                if (i == 1 || i == 2 || i == 4 || i == 7 || i == 8)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 2)
            {
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 9)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 2.5)
            {
                if (i == 1 || i == 3)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 3)
            {
                if (i == 1)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences3[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 3.5)
            {
                storytext.text = sentences3_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 4)
            {
                storytext.text = sentences4[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 4.5)
            {
                if (i == 1 || i == 2 || i == 3)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences4_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 5)
            {
                storytext.text = sentences5[i];
                clickNextButton = false;
            }
        }
    }

    public void Story1On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 1;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1 = new List<string>();
        //1, 2, 4, 7, 8
        sentences1.Add("�������̾�, ŧ."); //Į
        sentences1.Add("�׷� ���� �������̴�. �� ���� �ϳ��� ���� �� ����."); //ŧ
        sentences1.Add("�׶��� �����̳� �Ƶ�ٵ� ���� �����ϴ±���."); //ŧ
        sentences1.Add("�̵������� �þ�����."); //Į
        sentences1.Add("�� �� �ų信 ���� �ڵ�����. ������ ���ǳ� �߱��ϴ� ���� �ձ��� �����ϰ� ������ �޶�. �츰 �ξ� ū ��ǥ! �ξ� ū ������ �ٽ��� ��������!"); //ŧ
        sentences1.Add("�� �ձ��̱⵵ �߾�. �׷��� ���� �׸� ���� ŧ. ���� �ɸ����⸦ ������"); //Į
        sentences1.Add("�� �̻� �װ� ���� ������� ������ �������� ��!!!"); //Į
        sentences1.Add("�ƴ�! ��� ������ �̵��� ��¥ ���� ���� �����ܵ��� ���� �������� �������̾�! �� �˼� �Ƿ��� �������� �����߾�. ������ ���� ������!"); //ŧ
        sentences1.Add("������ �̹��� �ʸ� ���ʶ߷��ָ�!"); //ŧ
        sentences1.Add("��¿ �� ����. �׶��� �����̳�, �� ������� �Ǵ� �� ���� �ž�!"); //Į
        size = sentences1.Count;

        Storykal();
        i = 0;
        storytext.text = sentences1[i];
    }

    public void Story2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 2;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //1, 3, 5, 7, 9
        sentences2.Add("�̷� ������ ������� �� �� ���� ���ʶ߸� �� ����."); //Į
        sentences2.Add("���� �׷���? �� �� �ϴ÷� ġ���� ��븦 ���� ���� �̹��� ������ ���� ���������� �ؾ� �ڱ�!"); //ŧ
        sentences2.Add("ŧ, �츮 ���� �ϳ� �ϴ� �� �?"); //Į
        sentences2.Add("���� ����?"); //ŧ
        sentences2.Add("�� ���ݵ� �װ� �� �ձ��� �������̾���� �ߴٰ� �������ݾ�."); //Į
        sentences2.Add("�翬����. �� �׳� ��¼�� �� �ڸ��� ���� �� �� ���̾�!"); //ŧ
        sentences2.Add("�׷� �׶�ó�� �ܷ���. �츮 �� ���� �־��� ���ڸ� �� ���� ��������."); //Į
        sentences2.Add("Į. �� ���� ������ �׷� ������ �����̳� �� �� �ƴ� �ž�?!"); //ŧ
        sentences2.Add("��? �ڽž���? �װ� ������ ���� ���ϴٸ� �� ���� ���� ���ε� �� �̰ܾ���!"); //Į
        sentences2.Add("�׷�, �ʸ� �� ������ �׿��ָ�. �׶� �������� ���� �� ��¥ �Ƿ��� ��������!"); //ŧ
        size = sentences2.Count;

        Storykal();
        i = 0;
        storytext.text = sentences2[i];
    }
    public void Story2_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 2.5;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2_2 = new List<string>();
        //0, 1, 3
        sentences2_2.Add("Ū..."); //ŧ
        sentences2_2.Add("�׶��� �����̳�... �ʸ� ��������..."); //ŧ
        sentences2_2.Add("�ƴ�!!! �� �׶��� ���ݵ� ���� ���!!! �� �� ���� ������ �����ִ� ��, �װ� ���ϴ� ��� �� �� ���� �ž�!!!"); //Į
        sentences2_2.Add("��Ҹ� ���� ��!"); //ŧ
        size = sentences2_2.Count;

        Storycul();
        i = 0;
        storytext.text = sentences2_2[i];
    }

    public void Story3On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 3;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3 = new List<string>();
        //1
        sentences3.Add("�װ�...!"); //Į
        sentences3.Add("�� �̰��� ���� ���� ��Ȯ�� ����! �ʸ� ������ �ν��ָ�!"); //ŧ
        sentences3.Add("(�ɸ����⿡�� �̻��� ���̳�...)"); //ŧ
        size = sentences3.Count;

        Storykal();
        i = 0;
        storytext.text = sentences3[i];
    }
    public void Story3_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 3.5;

        playerimage1.SetActive(true);
        bossimage1.SetActive(true);
        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3_2 = new List<string>();
        sentences3_2.Add("!!!"); //Į, ŧ ���ÿ�
        size = sentences3_2.Count;

        i = 0;
        storytext.text = sentences3_2[i];
    }

    public void Story4On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 4;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences4 = new List<string>();
        sentences4.Add("(�̷��̷�)"); //Į
        sentences4.Add("(���� ���� ���� �ʴ´�.)"); //Į
        sentences4.Add("ŧ, �װ� �װ� �����ϱ⿣ �ʹ� ���ſ� �����̾�..."); //Į
        size = sentences4.Count;

        Storykal();
        i = 0;
        storytext.text = sentences4[i];
    }
    public void Story4_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 4.5;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences4_2 = new List<string>();
        //1, 2, 3
        sentences4_2.Add("��� ���� �ž�! ���� �ɸ����⸦ ����!"); //Į
        sentences4_2.Add("�̹��� ����������, �׶�ó�� �������� �ʰ� ������ ������ �� ��ƹ��� �ž�."); //ŧ
        sentences4_2.Add("���� �������� �ڸ����� ���������� ������ ���� �ʵ� ���� �����Դ� ����� ������ �� �ž�."); //ŧ
        sentences4_2.Add("�� ����, Į."); //ŧ
        sentences4_2.Add("�ȵ�! ���� ����!!!"); //Į
        size = sentences4_2.Count;

        Storykal();
        i = 0;
        storytext.text = sentences4_2[i];
    }

    public void Story5On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 5;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences5 = new List<string>();
        sentences5.Add("..."); //Į
        size = sentences5.Count;

        Storykal();
        i = 0;
        storytext.text = sentences5[i];
    }

    void Storykal()
    {
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
    }
    void Storycul()
    {
        playerimage1.SetActive(false);
        bossimage1.SetActive(true);
    }

    public void StoryOff()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().ResumeMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 0;

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);

        clickNextButton = false;
    }
}