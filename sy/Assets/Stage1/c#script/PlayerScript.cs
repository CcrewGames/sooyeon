using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int heart; //플레이어 체력

    public int move; //플레이어 이동 변수
    private bool tremble; //플레이어 ㅂㄷㅂㄷ 변수

    //플레이어 이동 관련
    float speed = 3f;
    float xm = -1.6f;

    //플레이어 ㅂㄷㅂㄷ 관련
    float speed1 = 3f;
    private int movey; //좌우
    float x0;
    float x1;

    bool healmode; //힐모드 제어용 변수
    int random; //힐모드 난수

    //난수 표시 관련
    public GameObject number;
    private GameObject num;
    private GameObject num1;
    private GameObject num2;
    float xn = -7f;
    float yn = 1.3f;
    float dis = 0.25f;

    bool end; //게임 실패 변수

    public GameObject punch;
    private GameObject target; //마우스 클릭 확인용 변수

    public Animator animator;

    void CastRay() //마우스 클릭 확인용 함수
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }

    void Start() //게임 시작 초기화
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

    void setting() //난수 설정
    {
        random = Random.Range(1, 15);
        nummaker();
    }

    void nummaker() //플레이어 머리 위 난수 생성 함수
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99) //난수가 십의 자리일 때
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
        else if (random > 0 && random <= 9) //난수가 일의 자리일 때
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
        if (movey == 1) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
        else if (movey == 2) //ㅂㄷㅂㄷ
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

        if (heart <= 0 && end == false) //실패
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

            if (target == this.gameObject && healmode == false) //힐모드 시작
            {
                healmode = true;
                punch.GetComponent<PunchScript>().re();
                punch.GetComponent<PunchScript>().ScrollChange2();
                punch.GetComponent<PunchScript>().punchmode = 2;
                punch.GetComponent<PunchScript>().PunchMode();
                setting();
                animator.SetBool("heal", true);
            }
            else if (target == this.gameObject && healmode == true) //힐모드 종료
            {
                if (punch.GetComponent<PunchScript>().result == random) //난수 = 결과 일치
                {
                    heart += random;
                    num.SetActive(false);
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                else //난수 = 결과 불일치
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

        if (Input.GetKeyDown(KeyCode.Space)) //임의 피격
        {
            animator.SetTrigger("fight");
        }
    }

    void Run() //중간으로 이동 함수
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xm, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("walk", true);
        Invoke("Re", 5f);
    }

    void Re() //원위치로 이동 함수
    {
        move = 2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-7 + xm, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("walk", true);
        Invoke("Next", 5f);
    }

    public void Next() //이동 변수 초기화 함수
    {
        move = 0;
        animator.SetBool("walk", false);
    }

    void Tremble() //덜덜 함수
    {
        CancelInvoke("Stop");
        x0 = transform.position.x;
        x1 = x0 + 0.1f;

        movey = 1;
        tremble = true;

        Invoke("Stop", 0.35f);
    }

    void Stop() //덜덜 멈추는 함수
    {
        movey = 0;
        tremble = false;
    }
}

