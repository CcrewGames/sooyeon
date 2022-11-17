using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalScript : MonoBehaviour
{
    public Animator animator;

    public GameObject Cul;
    public GameObject stage;
    public GameObject story;
    public GameObject punch;

    public int heart; //�÷��̾� ü��

    //�÷��̾� �̵� ����
    public int move; //�÷��̾� �̵� ����
    float speed = 3f;

    //�÷��̾� �������� ����
    private bool tremble; //�÷��̾� �������� ����
    private int movey; //�¿�
    float x0;
    float x1;
    float speed1 = 3f;

    bool healmode; //����� ����� ����
    int random; //����� ����
    //���� ǥ�� ����
    public GameObject number;
    private GameObject num1; //���� �ڸ�
    private GameObject num2; //���� �ڸ�
    float xn = -7f;
    float yn = 1.3f;
    float dis = 0.25f;

    //���
    public GameObject Background;
    public GameObject Background2;
    public GameObject Background3;
    public GameObject floor;
    public GameObject floor2;
    public GameObject floor3;
    bool f; //��� ������ ����
    float b = -27.5f;

    bool end; //���� ���� ����

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

    void Start() //���� ���� �ʱ�ȭ
    {
        animator = GetComponent<Animator>();

        heart = 100;

        move = 0;
        tremble = false;
        movey = 0;

        healmode = false;

        num1 = Instantiate(number, new Vector2(xn, yn), transform.rotation);
        num2 = Instantiate(number, new Vector2(xn, yn), transform.rotation);
        num1.SetActive(false);
        num2.SetActive(false);

        Background.transform.position = new Vector2(0, Background.transform.position.y);
        f = false;
        
        end = false;
    }

    void FixedUpdate()
    {
        if (movey == 1) //��������
            transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
        else if (movey == 2) //��������
            transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);

        if (move == 1 && transform.position.x < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), Time.deltaTime * speed);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        if (move == 2 && transform.position.x > -7)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-7, transform.position.y), Time.deltaTime * (speed + 2));

            if (Background.transform.position.x > b)
                Background.transform.position = Vector2.MoveTowards(Background.transform.position, new Vector2(b, Background.transform.position.y), Time.deltaTime * (speed + 2));
            else if (Background.transform.position.x <= b)
                Background.transform.position = new Vector2(-b, Background.transform.position.y);
        }

        if (transform.position.x >= 0 && f == false)
        {
            if (Background.transform.position.x > b)
                Background.transform.position = Vector2.MoveTowards(Background.transform.position, new Vector2(b, Background.transform.position.y), Time.deltaTime * (speed + 2));
            else if (Background.transform.position.x <= b)
                Background.transform.position = new Vector2(-b, Background.transform.position.y);
        }

        Background2.transform.position = new Vector2(Background.transform.position.x + 55f, Background.transform.position.y);
        Background3.transform.position = new Vector2(Background.transform.position.x - 55f, Background.transform.position.y);

        floor.transform.position = new Vector2(Background.transform.position.x, floor.transform.position.y);
        floor2.transform.position = new Vector2(Background2.transform.position.x, floor2.transform.position.y);
        floor3.transform.position = new Vector2(Background3.transform.position.x, floor3.transform.position.y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && stage.GetComponent<Stage3>().fortime == 1 && stage.GetComponent<Stage3>().pausemode == false && stage.GetComponent<Stage3>().stage < 2)
        {
            CastRay();

            if (target == this.gameObject && healmode == false) //����� ����
            {
                animator.SetBool("heal", true);
                punch.GetComponent<PunchScript>().re();
                punch.GetComponent<PunchScript>().ScrollChange2();
                punch.GetComponent<PunchScript>().punchmode = 2;
                punch.GetComponent<PunchScript>().PunchMode();
                setting();
                healmode = true;
            }
            else if ((target == this.gameObject || target == num1 || target == num2) && healmode == true) //����� ����
            {
                animator.SetBool("heal", false);
                if (punch.GetComponent<PunchScript>().result == random) //���� = ��� ��ġ
                {
                    if (heart + random < 100)
                        heart += random;
                    else
                        heart = 100;
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                else //���� = ��� ����ġ
                {
                    if (tremble == false)
                        Tremble();
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                punch.GetComponent<PunchScript>().punchmode = 1;
                punch.GetComponent<PunchScript>().PunchMode();
                healmode = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().going == 1) //���� �ǰ�
        {
            animator.SetTrigger("attack");
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who = 1;
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num1setting();
        }

        if (tremble == true)
        {
            if (transform.position.x >= x1)
                movey = 1;
            else if (transform.position.x <= x0)
                movey = 2;
        }

        if (heart <= 0 && end == false) //����
        {
            end = true;
            GameObject.Find("ending").GetComponent<endingscene>().Playerpowerend();
        }
    }

    void setting() //���� ����
    {
        random = Random.Range(5, 10);
        nummaker();
    }
    void nummaker() //�÷��̾� �Ӹ� �� ���� ���� �Լ�
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99) //������ ���� �ڸ��� ��
        {
            int b = random / 10;
            int a = random % 10;
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[a];
            SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
            spriteB.sprite = sprites[b];

            num1.transform.position = new Vector2(xn + dis, yn);
            num1.SetActive(true);
            num2.SetActive(true);
        }
        else if (random > 0 && random <= 9) //������ ���� �ڸ��� ��
        {
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[random];

            num1.transform.position = new Vector2(xn, yn);
            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    void Tremble() //���� �Լ�
    {
        CancelInvoke("Stop");
        x0 = transform.position.x;
        x1 = x0 + 0.1f;

        movey = 1;
        tremble = true;

        Invoke("Stop", 0.35f);
    }
    void Stop() //���� ���ߴ� �Լ�
    {
        movey = 0;
        transform.position = new Vector2(x0, transform.position.y);
        tremble = false;
    }

    public void HealStop()
    {
        animator.SetBool("heal", false);
        num1.SetActive(false);
        num2.SetActive(false);
        random = 0;
        punch.GetComponent<PunchScript>().re();
    }

    //�������� �̵�
    public void Run() //�̵� ��� �Լ�
    {
        Invoke("Run_", 1f);
    }
    void Run_() //�ִϸ��̼� �̸�
    {
        animator.SetBool("walk", true);
        Invoke("RunM", 0.6f);
    }
    void RunM() //�߰����� �̵� �Լ�
    {
        move = 1;
        Invoke("Find", 5f);
    }
    void Find() //���� ����ħ! �Լ�
    {
        move = 0;
        f = true;
        animator.SetBool("walk", false);
        if (stage.GetComponent<Stage3>().stage < 2)
        {
            animator.SetTrigger("surprise");
        }
        Invoke("Re", 2f);
    }
    void Re() //����ġ�� �̵� �Լ�
    {
        Cul.GetComponent<CulScript>().move1();
        move = 2;
        f = false;
        Invoke("Next", 5f);
        if (stage.GetComponent<Stage3>().stage == 0)
        {
            Invoke("Story1", 2.85f);
        }
    }
    public void Next() //�̵� ���� �ʱ�ȭ �Լ�
    {
        move = 0;
    }

    void Story1() //���丮1
    {
        story.GetComponent<Story3Script>().Story1On();
    }
}

