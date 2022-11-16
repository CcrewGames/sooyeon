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

    private GameObject target; //마우스 클릭 확인용 변수

    public int heart; //큘 체력

    //큘 이동 관련
    public int move; //큘 이동 변수
    float xb = 4.5f;
    float speed = 3f;

    //큘 ㅂㄷㅂㄷ, 둥둥 관련
    private int movey; //좌우상하
    private bool tremble; //큘 ㅂㄷㅂㄷ 변수
    float x0;
    float x1;
    float speed1 = 3f;
    float y0; //큘 둥둥 변수
    float y1;
    float speed2 = 0.4f;

    //난수 표시 관련
    int random;
    public GameObject number;
    private GameObject num1; //일의 자리
    private GameObject num2; //십의 자리
    float dis = 0.25f;
    float dis1 = 2.5f; //숫자 머리 위 간격

    public int monnum;

    void Start() //게임 시작 초기화
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
        if (random > 9 && random <= 99) //십의 자리일 때
        {
            num1.transform.position = new Vector2(transform.position.x + dis, transform.position.y + dis1);
        }
        else if (random > 0 && random <= 9) //일의 자리일 때
        {
            num1.transform.position = new Vector2(transform.position.x, transform.position.y + dis1);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        if (move == 1)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xb, transform.position.y), Time.deltaTime * (speed + 2));

        if (move == 2)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xb + 7, transform.position.y), Time.deltaTime * (speed + 2));

        if (movey == 1) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
        else if (movey == 2) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);

        if (movey == 3) //둥둥
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

    void setting() //난수 설정
    {
        random = Random.Range(30, 40);
        nummaker();
    }

    void nummaker() //플레이어 머리 위 난수 생성 함수
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99) //난수가 십의 자리일 때
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
        else if (random > 0 && random <= 9) //난수가 일의 자리일 때
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

