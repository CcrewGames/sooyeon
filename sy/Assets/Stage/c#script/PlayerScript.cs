using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int heart; //�÷��̾� ü��

    public int move; //�÷��̾� �̵� ����
    private bool tremble; //�÷��̾� �������� ����

    //�÷��̾� �̵� ����
    float speed = 3f;
    float xm = -1.6f;

    //�÷��̾� �������� ����
    float speed1 = 3f;
    private int movey; //�¿�
    float x0;
    float x1;

    bool healmode; //����� ����� ����
    int random; //����� ����

    //���� ǥ�� ����
    public GameObject number;
    private GameObject num1; //���� �ڸ�
    private GameObject num2; //���� �ڸ�
    float xn = -7f;
    float yn = 1.3f;
    float dis = 0.25f;

    bool end; //���� ���� ����

    public GameObject punch;
    private GameObject target; //���콺 Ŭ�� Ȯ�ο� ����

    public Animator animator;

    public GameObject Background;
    public GameObject Floor;
    public GameObject Background2;
    public GameObject Floor2;
    public GameObject Background3;
    public GameObject Floor3;
    bool f;
    float b = -27.5f;

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
        heart = 10000;
        move = 0;
        movey = 0;
        tremble = false;

        healmode = false;

        num1 = Instantiate(number, new Vector2(xn, yn), transform.rotation);
        num2 = Instantiate(number, new Vector2(xn, yn), transform.rotation);

        num1.SetActive(false);
        num2.SetActive(false);

        animator = GetComponent<Animator>();

        end = false;

        Background.transform.position = new Vector3(0, Background.transform.position.y, 2);
        Floor.transform.position = new Vector3(0, Floor.transform.position.y, 1);
        f = false;
    }

    void setting() //���� ����
    {
        random = Random.Range(1, 15);
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
            SpriteRenderer spriteR = num1.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprites[random];

            num1.transform.position = new Vector2(xn, yn);
            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (movey == 1) //��������
            transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
        else if (movey == 2) //��������
            transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);
    }

    void Update()
    {
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
            GameObject.Find("Stage").GetComponent<Stage>().Fail();
            GameObject.Find("ending").GetComponent<endingscene>().Playerpowerend();
        }

        if (move == 1 && transform.position.x < xm)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xm, transform.position.y, 0), Time.deltaTime * speed);
        }

        if (move == 2 && transform.position.x > -7 + xm)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-7 + xm, transform.position.y, 0), Time.deltaTime * (speed + 2));

            if (Background.transform.position.x > b)
                Background.transform.position = Vector3.MoveTowards(Background.transform.position, new Vector3(b, Background.transform.position.y, 2), Time.deltaTime * (speed + 2));
            else if (Background.transform.position.x <= b)
                Background.transform.position = new Vector3(-b, Background.transform.position.y, 2);
        }

        if (move == 3 && transform.position.x <= -0.01f + xm)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xm, transform.position.y, 0), Time.deltaTime * (speed + 2));
        }
        if (move == 3 && transform.position.x >= -0.01f + xm)
        {
            Find1();
        }

        if (transform.position.x >= xm && f == false)
        {
            if (Background.transform.position.x > b)
                Background.transform.position = Vector3.MoveTowards(Background.transform.position, new Vector3(b, Background.transform.position.y, 2), Time.deltaTime * (speed + 2));
            else if (Background.transform.position.x <= b)
                Background.transform.position = new Vector3(-b, Background.transform.position.y, 2);
        }

        Floor.transform.position = new Vector3(Background.transform.position.x, Floor.transform.position.y, 1);
        Background2.transform.position = new Vector3(Background.transform.position.x + 55, Background.transform.position.y, 2);
        Floor2.transform.position = new Vector3(Background.transform.position.x + 55, Floor.transform.position.y, 1);
        Background3.transform.position = new Vector3(Background.transform.position.x - 55, Background.transform.position.y, 2);
        Floor3.transform.position = new Vector3(Background.transform.position.x - 55, Floor.transform.position.y, 1);

        if (Input.GetMouseButtonDown(0) && GameObject.Find("Stage").GetComponent<Stage>().fortime == 1)
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

        if (Input.GetKeyDown(KeyCode.Space)) //���� �ǰ�
        {
            animator.SetTrigger("fight");
        }

        num2.transform.position = new Vector3(num1.transform.position.x - 2 * dis, num1.transform.position.y, -1);
    }

    public void HealStop()
    {
        animator.SetBool("heal", false);
        num1.SetActive(false);
        num2.SetActive(false);
        random = 0;
        punch.GetComponent<PunchScript>().re();
    }

    public void Run() //�̵� ��� �Լ�
    {
        Invoke("Run1", 1f);
    }

    void Run1() //�߰����� �̵� �Լ�
    {
        move = 1;
        animator.SetBool("walk", true);
        Invoke("Find", 5f);
    }

    void Find() //���� ����ħ! �Լ�
    {
        f = true;
        animator.SetBool("walk", false);
        Invoke("Re", 2f);
    }

    void Re() //����ġ�� �̵� �Լ�
    {
        move = 2;
        Invoke("Next", 5f);
        GameObject.Find("Stage").GetComponent<Stage>().monstermove = 1;
        GameObject.Find("Stage").GetComponent<Stage>().MonsterMove();
        f = false;
    }

    public void Next() //�̵� ���� �ʱ�ȭ �Լ�
    {
        move = 0;
    }

    public void Run_() //�̵� ��� �Լ�2
    {
        Invoke("Run2", 1f);
    }

    void Run2() //�߰����� �̵� �Լ�2
    {
        move = 3;
        animator.SetBool("walk", true);
    }

    void Find1() //��~ �Լ�
    {
        move = 0;
        animator.SetBool("walk", false);
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
        tremble = false;
    }
}

