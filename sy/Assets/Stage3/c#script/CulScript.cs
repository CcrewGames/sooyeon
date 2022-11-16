using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CulScript : MonoBehaviour
{
    public Animator animator;

    public GameObject AttackBar;
    public GameObject stage;
    public GameObject story;
    public GameObject punch;

    private GameObject target; //���콺 Ŭ�� Ȯ�ο� ����

    public int heart; //ŧ ü��

    //ŧ �̵� ����
    public int move; //ŧ �̵� ����
    float xb = 4.5f;
    float speed = 3f;

    //ŧ ��������, �յ� ����
    private int movey; //�¿����
    private bool tremble; //ŧ �������� ����
    float x0;
    float x1;
    float speed1 = 3f;
    float y0; //ŧ �յ� ����
    float y1;
    float speed2 = 0.4f;

    //���� ǥ�� ����
    int random;
    public GameObject number;
    private GameObject num1; //���� �ڸ�
    private GameObject num2; //���� �ڸ�
    float dis = 0.25f;
    float dis1 = 2.5f; //���� �Ӹ� �� ����

    public int monnum;

    void Start() //���� ���� �ʱ�ȭ
    {
        animator = GetComponent<Animator>();

        heart = 100;

        transform.position = new Vector2(xb + 7, transform.position.y);
        move = 0;

        tremble = false;

        movey = 3;
        y0 = transform.position.y;
        y1 = y0 + 0.2f;

        AttackBar.SetActive(false);

        num1 = Instantiate(number, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        num2 = Instantiate(number, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        num1.SetActive(false);
        num2.SetActive(false);
    }

    void FixedUpdate()
    {
        if (random > 9 && random <= 99) //���� �ڸ��� ��
        {
            num1.transform.position = new Vector2(transform.position.x + dis, transform.position.y + dis1);
        }
        else if (random > 0 && random <= 9) //���� �ڸ��� ��
        {
            num1.transform.position = new Vector2(transform.position.x, transform.position.y + dis1);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        if (move == 1)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xb, transform.position.y), Time.deltaTime * (speed + 2));

        if (move == 2)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xb + 7, transform.position.y), Time.deltaTime * (speed + 2));

        if (movey == 1) //��������
            transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
        else if (movey == 2) //��������
            transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);

        if (movey == 3) //�յ�
            transform.position = transform.position - transform.up * speed2 * Time.deltaTime;
        else if (movey == 4)
            transform.position = transform.position + transform.up * speed2 * Time.deltaTime;
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

        if (transform.position.y >= y1)
            movey = 3;
        else if (transform.position.y <= y0)
            movey = 4;
    }

    void setting() //���� ����
    {
        random = Random.Range(30, 40);
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

            num1.SetActive(true);
            num2.SetActive(true);
        }
        else if (random > 0 && random <= 9) //������ ���� �ڸ��� ��
        {
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[random];

            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    public void AttackBarOn()
    {
        Invoke("AttackBarOn_", 0.5f);
    }
    public void AttackBarOn_()
    {
        AttackBar.SetActive(true);
    }
    public void AttackBarOff()
    {
        AttackBar.SetActive(true);
    }

    public void move1()
    {
        transform.position = new Vector2(xb + 7, transform.position.y);
        move = 1;
    }
    public void move2()
    {
        Invoke("move2_", 1.5f);
    }
    void move2_()
    {
        move = 2;
    }
}

