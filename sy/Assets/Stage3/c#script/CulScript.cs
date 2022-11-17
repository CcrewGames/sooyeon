using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CulScript : MonoBehaviour
{
    public Animator animator;

    public GameObject AttackBar;
    public GameObject KalAttackBar;
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

    //칼 날라가기~
    public GameObject AttackBar1;
    public GameObject flynum;
    private GameObject fnum1; //일의 자리
    private GameObject fnum2; //십의 자리
    GameObject fly;
    float xk = 6.5f;
    float yk = 2.8f;
    int anum;
    float xn = 6f;
    float yn = 2.8f;
    public float xf;
    public float yf;
    float speed3 = 7.5f;
    bool flymode;
    int numnum;

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

        fly = Instantiate(AttackBar1, new Vector2(xk, yk), transform.rotation);
        fly.SetActive(false);
        flymode = false;
        fnum1 = Instantiate(flynum, new Vector2(xn, yn), transform.rotation);
        fnum2 = Instantiate(flynum, new Vector2(xn - 0.4f, yn), transform.rotation);
        fnum1.SetActive(false);
        fnum2.SetActive(false);
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

        if (flymode == true)
        {
            fly.transform.position = Vector2.Lerp(fly.transform.position, new Vector2(xf, yf), Time.deltaTime * speed3);
        }
        if (fly.transform.position.x <= xf + 1.5f && flymode == true)
        {
            Flyoff();
        }
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

        if (Input.GetKeyDown(KeyCode.D)) //임의 피격
        {
            CulPlus();
        }
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

    public void CulPlus()
    {
        numnum = Random.Range(1, 6);
        if (numnum == 1)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum1;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x1;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y1;
        }
        else if (numnum == 2)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum2;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x2;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y2;
        }
        else if (numnum == 3)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum3;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x3;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y3;
        }
        else if (numnum == 4)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum4;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x4;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y4;
        }
        else if (numnum == 5)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum5;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x5;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y5;
        }
        GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who = 2;
        flynummaker();
        Invoke("Fly", 1f);
    }

    void flynummaker() //플레이어 머리 위 난수 생성 함수
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        int b = anum / 10;
        int a = anum % 10;
        SpriteRenderer spriteC = fnum1.GetComponent<SpriteRenderer>();
        spriteC.sprite = sprites[a];
        SpriteRenderer spriteD = fnum2.GetComponent<SpriteRenderer>();
        spriteD.sprite = sprites[b];

        fnum1.SetActive(true);
        fnum2.SetActive(true);
    }

    public void Fly()
    {
        animator.SetTrigger("attack");
        fly.SetActive(true);
        fnum1.SetActive(false);
        fnum2.SetActive(false);
        flymode = true;

        float r1 = Mathf.Atan2(yf - yk, xf - xk) * Mathf.Rad2Deg + 180;
        fly.transform.rotation = Quaternion.Euler(0, 0, r1);
    }
    public void Flyoff()
    {
        if (numnum == 1)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num1setting();
        }
        else if (numnum == 2)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num2setting();
        }
        else if (numnum == 3)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num3setting();
        }
        else if (numnum == 4)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num4setting();
        }
        else if (numnum == 5)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num5setting();
        }

        fly.transform.position = new Vector2(xk, yk);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode = false;
    }

    public void AttackBarOn()
    {
        Invoke("AttackBarOn_", 0.5f);
    }
    public void AttackBarOn_()
    {
        AttackBar.SetActive(true);
        KalAttackBar.SetActive(true);
    }
    public void AttackBarOff()
    {
        AttackBar.SetActive(false);
        KalAttackBar.SetActive(false);
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

