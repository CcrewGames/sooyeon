using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Monster : MonoBehaviour
{
    int heart = 3; //몬스터 체력
    private bool move; //몬스터 이동 변수

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

    Rigidbody2D rigid;

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

        num = Instantiate(number, transform.position, transform.rotation);
        num1 = Instantiate(number, transform.position, transform.rotation);
        num2 = Instantiate(number, transform.position, transform.rotation);

        num.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);

        setting();

        hpbar1 = Instantiate(circle, transform.position, transform.rotation);
        hpbar2 = Instantiate(circle, transform.position, transform.rotation);
        hpbar3 = Instantiate(circle, transform.position, transform.rotation);
    }

    void setting() //난수 설정
    {
        random = Random.Range(1, 15);
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
        else if (random > 0 && random <= 9)// 일의 자리일 때
        {
            SpriteRenderer spriteR = num.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprites[random];

            num.SetActive(true);
            num1.SetActive(false);
            num2.SetActive(false);
        }
    }

    void Awake() //start()보다 먼저 호출
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (move == true)
            rigid.velocity = new Vector2(-1, rigid.velocity.y); //몬스터에게 속도 줌
    }

    public void Update()
    {
        if (heart == 0) //삭제
        {
            Destroy(num);
            Destroy(num1);
            Destroy(num2);

            Destroy(hpbar1);
            Destroy(hpbar2);
            Destroy(hpbar3);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target == this.gameObject)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == random) //난수 = 결과 일치
                {
                    heart--;
                    OnDamaged();
                    Sprite[] sprites = Resources.LoadAll<Sprite>("hpmonster");
                    if (heart == 2)
                    {
                        SpriteRenderer sprite1 = hpbar3.GetComponent<SpriteRenderer>();
                        sprite1.sprite = sprites[0];
                        setting();
                    }
                    else if (heart == 1)
                    {
                        SpriteRenderer sprite2 = hpbar2.GetComponent<SpriteRenderer>();
                        sprite2.sprite = sprites[0];
                        setting();
                    }
                    else if (heart == 0)
                    {
                        SpriteRenderer sprite1 = hpbar1.GetComponent<SpriteRenderer>();
                        sprite1.sprite = sprites[0];
                    }
                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                    GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //임의 피격
        {
            heart--;
            OnDamaged();
            Sprite[] sprites = Resources.LoadAll<Sprite>("hpmonster");
            if (heart == 2)
            {
                SpriteRenderer sprite1 = hpbar3.GetComponent<SpriteRenderer>();
                sprite1.sprite = sprites[0];
                setting();
            }
            else if (heart == 1)
            {
                SpriteRenderer sprite2 = hpbar2.GetComponent<SpriteRenderer>();
                sprite2.sprite = sprites[0];
                setting();
            }
            else if (heart == 0)
            {
                SpriteRenderer sprite1 = hpbar1.GetComponent<SpriteRenderer>();
                sprite1.sprite = sprites[0];
            }
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Attack();
        }
    }

    void Attack() //공격 함수
    {
        move = false;
        rigid.velocity = Vector2.zero;
        Vector2 JumpVelocity = new Vector2(3, 3);
        rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);
        GameObject.Find("Player").GetComponent<PlayerScript>().heart -= 5;
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hurt2");

        Invoke("Stop", 1f); // 1초 스턴
    }

    void OnDamaged() //피격 함수
    {
        if (heart != 0)
        {
            CancelInvoke("Stop");
            move = false;
            rigid.velocity = Vector2.zero;
            Vector2 JumpVelocity = new Vector2(5, 4);
            rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);

            Invoke("Stop", 2f); //2초 스턴
        }
        else
        {
            CancelInvoke("Stop");
            move = false;
            rigid.velocity = Vector2.zero;
            Vector2 JumpVelocity = new Vector2(2, 2);
            rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);

            Invoke("Destroy", 0.5f);
        }
    }

    void Stop() //스턴 함수
    {
        move = true;
    }

    void Destroy() //삭제 함수
    {
        Destroy(gameObject);
        GameObject.Find("Stage").GetComponent<Stage>().remain -= 1;
    }
}