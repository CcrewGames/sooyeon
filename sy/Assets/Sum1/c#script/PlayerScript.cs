using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int heart; //플레이어 체력
    public int move; //플레이어 이동 변수
    float speed = 4f; //플레이어 이동속도

    public GameObject punch;

    bool healmode; //힐모드 제어용 변수
    int random; //힐모드 난수

    //난수 표시 관련
    public GameObject number;
    private GameObject num;
    private GameObject num1;
    private GameObject num2;
    float dis = 0.35f;

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

        healmode = false;

        num = Instantiate(number, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
        num1 = Instantiate(number, new Vector2(transform.position.x - dis, transform.position.y + 2), transform.rotation);
        num2 = Instantiate(number, new Vector2(transform.position.x + dis, transform.position.y + 2), transform.rotation);

        num.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);

        animator = GetComponent<Animator>();
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

    void Update()
    {
        if (heart == 0) //실패
        {
            Destroy(gameObject);
            GameObject.Find("Stage").GetComponent<Stage>().Fail();
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
                setting();
            }
            else if (target == this.gameObject && healmode == true) //힐모드 종료
            {
                if (punch.GetComponent<PunchScript>().result == random) //난수 = 결과 일치
                {
                    heart += random;
                    animator.SetTrigger("heal");
                    num.SetActive(false);
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                else //난수 = 결과 불일치
                {
                    Debug.Log("다시");
                    num.SetActive(false);
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                healmode = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //임의 피격
        {
            animator.SetTrigger("fight");
        }
    }

    void Run() //중간으로 이동 함수
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("walk", true);
        Invoke("Re", 5f);
    }

    void Re() //원위치로 이동 함수
    {
        move = 2;
        transform.position = Vector3.Lerp(transform.position, new Vector3(-7, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("walk", true);
        Invoke("Next", 5f);
    }

    public void Next() //이동 변수 초기화 함수
    {
        move = 0;
        animator.SetBool("walk", false);
    }
}

