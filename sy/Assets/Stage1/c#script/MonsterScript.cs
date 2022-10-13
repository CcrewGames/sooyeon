using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    int heart; //몬스터 체력

    private bool move; //몬스터 이동 변수
    float speed = 1f; //몬스터 이동 속도
    float x1 = -10f;

    private int movey; //몬스터 둥둥 변수
    float speed1 = 0.35f; //몬스터 둥둥 속도
    float y0;
    float y1;
    Vector3 st;

    public int random;

    //난수 표시 관련
    public GameObject number;
    private GameObject num;
    private GameObject num1;
    private GameObject num2;
    float dis = 0.3f;

    //체력바 표시 관련
    public GameObject circle;
    private GameObject hpbar1;
    private GameObject hpbar2;
    private GameObject hpbar3;
    float dis1 = 0.5f;

    private GameObject target; //마우스 클릭 확인용 변수

    public Animator animator; //애니

    void Awake() //start()보다 먼저 호출
    {
        animator = GetComponent<Animator>(); //애니
    }

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

    void Start() //스폰 초기화
    {
        move = true;
        movey = 1;
        y0 = transform.position.y;
        y1 = y0 + 0.3f;

        num = Instantiate(number, transform.position, transform.rotation);
        num1 = Instantiate(number, transform.position, transform.rotation);
        num2 = Instantiate(number, transform.position, transform.rotation);

        num.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);

        setting();

        heart = 3;
        hpbar1 = Instantiate(circle, transform.position, transform.rotation);
        hpbar2 = Instantiate(circle, transform.position, transform.rotation);
        hpbar3 = Instantiate(circle, transform.position, transform.rotation);
        HeartMaker();
    }

    public void respawn() //스폰 초기화
    {
        move = true;
        movey = 1;
        y0 = transform.position.y;
        y1 = y0 + 0.3f;

        setting();

        heart = 3;
        hpbar1.SetActive(true);
        hpbar2.SetActive(true);
        hpbar3.SetActive(true);
        HeartMaker();
    }

    void setting() //난수 설정
    {
        random = Random.Range(1, 30);
        nummaker();
    }

    void nummaker() //몬스터 머리 위 난수 생성 함수
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99) //십의 자리일 때
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
        else if (random > 0 && random <= 9) //일의 자리일 때
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
        if (move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(x1, transform.position.y), Time.deltaTime * speed);
            if (movey == 1)
                transform.position = transform.position + transform.up * speed1 * Time.deltaTime;
            else if (movey == 2)
                transform.position = transform.position - transform.up * speed1 * Time.deltaTime;
        }

        if(movey == 3)
            gameObject.transform.position = Vector3.Lerp(transform.position, st + new Vector3(3, 0, 0), Time.deltaTime * 2);

        if (movey == 4)
            gameObject.transform.position = Vector3.Lerp(transform.position, st + new Vector3(2, 0, 0), Time.deltaTime * 1);
    }

    public void Update()
    {
        if (transform.position.y >= y1)
            movey = 2;
        else if (transform.position.y <= y0)
            movey = 1;

        if (heart == 0) //UI 비활성화
        {
            num.SetActive(false);
            num1.SetActive(false);
            num2.SetActive(false);

            hpbar1.SetActive(false);
            hpbar2.SetActive(false);
            hpbar3.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target == this.gameObject)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == random) //난수 = 결과 일치
                {
                    heart--;
                    HeartMaker();
                    setting();
                    OnDamaged();
                    animator.SetInteger("hit", heart); //애니
                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                    GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //임의 피격
        {
            heart--;
            HeartMaker();
            setting();
            OnDamaged();
            animator.SetInteger("hit", heart); //애니
            GameObject.Find("Punch").GetComponent<PunchScript>().re();
            GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
        }

        //난수와 체력바 이동
        if (heart != 0)
        {
            num.transform.position = new Vector2(transform.position.x, transform.position.y + 3);
            num1.transform.position = new Vector2(transform.position.x - dis, transform.position.y + 3);
            num2.transform.position = new Vector2(transform.position.x + dis, transform.position.y + 3);

            hpbar1.transform.position = new Vector2(transform.position.x - dis1, transform.position.y + 2);
            hpbar2.transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            hpbar3.transform.position = new Vector2(transform.position.x + dis1, transform.position.y + 2);
        }
    }

    void HeartMaker()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("hpmonster");
        SpriteRenderer sprite3 = hpbar3.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite2 = hpbar2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1 = hpbar1.GetComponent<SpriteRenderer>();
        if (heart == 3)
        {
            sprite1.sprite = sprites[0];
            sprite2.sprite = sprites[0];
            sprite3.sprite = sprites[0];
        }
        else if (heart == 2)
        {
            sprite1.sprite = sprites[0];
            sprite2.sprite = sprites[0];
            sprite3.sprite = sprites[1];
        }
        else if (heart == 1)
        {
            sprite1.sprite = sprites[0];
            sprite2.sprite = sprites[1];
            sprite3.sprite = sprites[1];
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Attack();
            Debug.Log("충돌");
        }
    }

    void Attack() //공격 함수
    {
        move = false;
        movey = 4;

        GameObject.Find("Player").GetComponent<PlayerScript>().heart -= 3;
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hurt2");

        Invoke("Stop", 1f); // 1초 스턴
    }

    void OnDamaged() //피격 함수
    {
        if (heart != 0)
        {
            CancelInvoke("Stop");
            move = false;
            st = transform.position;
            movey = 3;

            Invoke("Stop", 2f); //2초 스턴
        }
        else
        {
            CancelInvoke("Stop");
            move = false;
            movey = 3;

            Invoke("Inactive", 2.2f);
        }
    }

    void Inactive() //죽음 처리 함수
    {
        gameObject.SetActive(false);
        GameObject.Find("Stage").GetComponent<Stage>().remain -= 1;
    }

    void Stop() //스턴 함수
    {
        move = true;
        movey = 1;
    }
}