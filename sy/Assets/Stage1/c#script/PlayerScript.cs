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
    private GameObject num;
    private GameObject num1;
    private GameObject num2;
    float xn = -7f;
    float yn = 1.3f;
    float dis = 0.25f;

    bool end; //���� ���� ����

    public GameObject punch;
    private GameObject target; //���콺 Ŭ�� Ȯ�ο� ����

    public Animator animator;

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
        heart = 100;
        move = 0;
        movey = 0;
        tremble = false;

        healmode = false;

        num = Instantiate(number, new Vector2(xn, yn), transform.rotation);
        num1 = Instantiate(number, new Vector2(xn - dis, yn), transform.rotation);
        num2 = Instantiate(number, new Vector2(xn + dis, yn), transform.rotation);

        num.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);

        animator = GetComponent<Animator>();

        end = false;
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
            int a = random / 10;
            int b = random % 10;
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[a];
            SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
            spriteB.sprite = sprites[b];

            num.SetActive(false);
            num1.SetActive(true);
            num2.SetActive(true);
        }
        else if (random > 0 && random <= 9) //������ ���� �ڸ��� ��
        {
            SpriteRenderer spriteR = num.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprites[random];

            num.SetActive(true);
            num1.SetActive(false);
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

        if (move == 1)
            Run();

        if (move == 2)
            Re();

        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target == this.gameObject && healmode == false) //����� ����
            {
                healmode = true;
                punch.GetComponent<PunchScript>().re();
                punch.GetComponent<PunchScript>().ScrollChange2();
                punch.GetComponent<PunchScript>().punchmode = 2;
                punch.GetComponent<PunchScript>().PunchMode();
                setting();
                animator.SetBool("heal", true);
            }
            else if (target == this.gameObject && healmode == true) //����� ����
            {
                if (punch.GetComponent<PunchScript>().result == random) //���� = ��� ��ġ
                {
                    heart += random;
                    num.SetActive(false);
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                else //���� = ��� ����ġ
                {
                    Tremble();
                    num.SetActive(false);
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                healmode = false;
                punch.GetComponent<PunchScript>().punchmode = 1;
                punch.GetComponent<PunchScript>().PunchMode();
                animator.SetBool("heal", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //���� �ǰ�
        {
            animator.SetTrigger("fight");
        }
    }

    void Run() //�߰����� �̵� �Լ�
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xm, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("walk", true);
        Invoke("Re", 5f);
    }

    void Re() //����ġ�� �̵� �Լ�
    {
        move = 2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-7 + xm, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("walk", true);
        Invoke("Next", 5f);
    }

    public void Next() //�̵� ���� �ʱ�ȭ �Լ�
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

