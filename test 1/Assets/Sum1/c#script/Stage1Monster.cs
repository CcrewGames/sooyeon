using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Monster : MonoBehaviour
{
    int heart = 3; //몬스터 체력
    private bool move; //몬스터 이동 변수

    public int random;

    //난수 표시 관련
    public GameObject number;
    private GameObject num1;
    private GameObject num2;
    float dis = 0.35f;

    //체력바 표시 관련
    public GameObject circle;
    private GameObject hpbar1;
    private GameObject hpbar2;
    private GameObject hpbar3;
    float dis1 = 0.5f;

    private bool stagemove;

    private GameObject target; //마우스 클릭 확인용 변수

    Rigidbody2D rigid;
    public Animator animator; //애니

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
        setting();
        move = true;
        stagemove = false;

        Sprite[] sprites = Resources.LoadAll<Sprite>("hpbar");
        hpbar1 = Instantiate(circle, new Vector2(transform.position.x - dis1, transform.position.y + 2), transform.rotation);
        SpriteRenderer sprite1 = hpbar1.GetComponent<SpriteRenderer>();
        sprite1.sprite = sprites[1];
        hpbar2 = Instantiate(circle, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
        SpriteRenderer sprite2 = hpbar2.GetComponent<SpriteRenderer>();
        sprite2.sprite = sprites[1];
        hpbar3 = Instantiate(circle, new Vector2(transform.position.x + dis1, transform.position.y + 2), transform.rotation);
        SpriteRenderer sprite3 = hpbar3.GetComponent<SpriteRenderer>();
        sprite3.sprite = sprites[1];
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
            num1 = Instantiate(number, transform.position, transform.rotation);
            num2 = Instantiate(number, transform.position, transform.rotation);
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[a];
            SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
            spriteB.sprite = sprites[b];
        }
        else if (random > 0 && random <= 9)// 일의 자리일 때
        {
            num1 = Instantiate(number, transform.position, transform.rotation);
            SpriteRenderer spriteR = num1.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprites[random];
        }
    }

    void Awake() //start()보다 먼저 호출
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); //애니
    }

    void FixedUpdate()
    {
        if (move == true)
            rigid.velocity = new Vector2(-1, rigid.velocity.y); //몬스터 자체에게 속도 줌
    }

    public void Update()
    {
        if (heart == 0 && stagemove == false) //삭제
        {
            Destroy(hpbar1);
            Destroy(hpbar2);
            Destroy(hpbar3);
            Invoke("Destroy", 2f);
            stagemove = true;
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
                    Sprite[] sprites = Resources.LoadAll<Sprite>("hpbar");
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
                    animator.SetFloat("hit", heart); //애니
                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                    GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //임의 피격
        {
            heart--;
            OnDamaged();
            Sprite[] sprites = Resources.LoadAll<Sprite>("hpbar");
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
            animator.SetFloat("hit", heart); //애니
            GameObject.Find("Punch").GetComponent<PunchScript>().re();
            GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
        }

        //난수와 체력바 이동
        if (random > 9 && heart != 0)
        {
            hpbar1.transform.position = new Vector2(transform.position.x - dis1, transform.position.y + 2);
            hpbar2.transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            hpbar3.transform.position = new Vector2(transform.position.x + dis1, transform.position.y + 2);
            num1.transform.position = new Vector2(transform.position.x - dis, transform.position.y + 3);
            num2.transform.position = new Vector2(transform.position.x + dis, transform.position.y + 3);
        }
        else if (random <= 9 && heart != 0)
        {
            hpbar1.transform.position = new Vector2(transform.position.x - dis1, transform.position.y + 2);
            hpbar2.transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            hpbar3.transform.position = new Vector2(transform.position.x + dis1, transform.position.y + 2);
            num1.transform.position = new Vector2(transform.position.x, transform.position.y + 3);
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
        Vector2 JumpVelocity = new Vector2(2, 2);
        rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);
        GameObject.Find("Player").GetComponent<PlayerScript>().heart -= 0;

        Invoke("Stop", 1f); // 1초 스턴
    }

    void OnDamaged() //피격 함수
    {
        if (random > 9 && random <= 99)
        {
            Destroy(num1);
            Destroy(num2);
        }
        else if (random > 0 && random <= 9)
        {
            Destroy(num1);
        }

        if(heart != 0)
        {
            CancelInvoke("Stop");
            move = false;
            rigid.velocity = Vector2.zero;
            Vector2 JumpVelocity = new Vector2(3, 3);
            rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);

            Invoke("Stop", 2f); //2초 스턴
        }
        else
        {
            CancelInvoke("Stop");
            move = false;
            rigid.velocity = Vector2.zero;
            Vector2 JumpVelocity = new Vector2(3, 3);
            rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);
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