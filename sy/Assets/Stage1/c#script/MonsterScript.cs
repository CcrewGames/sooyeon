using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public int heart; //몬스터 체력

    private bool move; //몬스터 이동 변수1
    private int movey; //몬스터 이동 변수2
    private bool tremble; //몬스터 ㅂㄷㅂㄷ 변수
    bool attack; //몬스터 공격 변수
    bool damaged; //몬스터 피격 변수

    //몬스터 이동 관련
    float speed = 0.8f;
    public float xm;

    //몬스터 둥둥 관련
    float speed1 = 0.35f;
    float y0;
    float y1;

    //몬스터 ㅂㄷㅂㄷ 관련
    float speed2 = 3f;
    float time;
    float x0;
    float x1;

    //몬스터 피격 관련
    float speed3 = 5;

    //몬스터 공격 관련
    public GameObject e1;
    public GameObject e2;
    private GameObject ef1;
    private GameObject ef2;

    public int random;

    //난수 표시 관련
    public GameObject number;
    private GameObject num1;
    private GameObject num2;
    float dis = 0.2f; //숫자 간격
    float dis3 = 2.3f; //숫자 머리 위 간격

    //체력바 표시 관련
    public GameObject circle;
    private GameObject hpbar1;
    private GameObject hpbar2;
    private GameObject hpbar3;
    float dis1 = 0.4f; //체력바 간격
    float dis2 = 1.6f; //체력바 머리 위 간격

    float dis4; //밀려나기

    private GameObject target; //마우스 클릭 확인용 변수

    public Animator animator; //애니

    public int monnum;

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

    void Start() //스폰
    {
        move = false;
        movey = 1;
        tremble = false;
        attack = true;
        damaged = true;

        y0 = transform.position.y;
        y1 = y0 + 0.3f;

        ef1 = Instantiate(e1, transform.position, transform.rotation);
        ef2 = Instantiate(e2, transform.position, transform.rotation);

        num1 = Instantiate(number, transform.position, transform.rotation);
        num2 = Instantiate(number, transform.position, transform.rotation);

        num1.SetActive(false);
        num2.SetActive(false);

        heart = 3;
        hpbar1 = Instantiate(circle, transform.position, transform.rotation);
        hpbar2 = Instantiate(circle, transform.position, transform.rotation);
        hpbar3 = Instantiate(circle, transform.position, transform.rotation);

        hpbar1.SetActive(false);
        hpbar2.SetActive(false);
        hpbar3.SetActive(false);
    }

    public void respawn1() //우측
    {
        speed = 5f;
        move = true;
        movey = 1;
        tremble = false;
        attack = true;
        damaged = true;
    }

    public void respawn2() //플레이어에게
    {
        speed = 0.8f;
        xm = -4f;
        move = false;
        move = true;
        movey = 1;
        tremble = false;
        attack = false;
        damaged = false;

        setting();

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
            int b = random / 10;
            int a = random % 10;
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[a];
            SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
            spriteB.sprite = sprites[b];

            num1.SetActive(true);
            num2.SetActive(true);
        }
        else if (random > 0 && random <= 9) //일의 자리일 때
        {
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[random];

            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xm, transform.position.y), Time.deltaTime * speed);
            if (movey == 1)
                transform.position = transform.position + transform.up * speed1 * Time.deltaTime;
            else if (movey == 2)
                transform.position = transform.position - transform.up * speed1 * Time.deltaTime;
        }
        
        if (movey == 3) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x - speed2 * Time.deltaTime, transform.position.y);
        else if (movey == 4) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x + speed2 * Time.deltaTime, transform.position.y);

        if (movey == 5) //맞음!
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(dis4, transform.position.y), Time.deltaTime * speed3);

        if (movey == 5 && transform.position.x > dis4 - 0.1f) //다시 걷기
        {
            CancelInvoke("Stop");
            Stop();
        }
    }

    public void Update()
    {
        if (transform.position.y >= y1)
            movey = 2;
        else if (transform.position.y <= y0)
            movey = 1;

        if (tremble == true)
        {
            if (transform.position.x >= x1)
                movey = 3;
            else if (transform.position.x <= x0)
                movey = 4;
        }

        if (transform.position.x >= xm && transform.position.x < xm + 0.1 && attack == false) //공격
        {
            move = false;
            Attack();
            attack = true;
        }

        if (Input.GetMouseButtonDown(0)) //피격
        {
            CastRay();

            if ((target == this.gameObject || target == num1 || target == num2) && GameObject.Find("Punch").GetComponent<PunchScript>().punchmode == 1 && damaged == false)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == random) //난수 = 결과 일치
                {
                    GameObject.Find("Stage").GetComponent<Stage>().xf = transform.position.x;
                    GameObject.Find("Stage").GetComponent<Stage>().yf = transform.position.y;
                    GameObject.Find("Stage").GetComponent<Stage>().monnum2 = monnum;

                    GameObject.Find("Stage").GetComponent<Stage>().Fly();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();
                }
                else
                {
                    Tremble();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Punch").GetComponent<PunchScript>().punchmode == 1) //임의 피격
        {
            OnDamaged();
            GameObject.Find("Punch").GetComponent<PunchScript>().re();
            GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
        }

        //난수와 체력바와 효과 이동
        if (heart != 0)
        {
            ef1.transform.position = new Vector2(transform.position.x - 2.45f, transform.position.y - 1.6f);
            ef2.transform.position = new Vector2(transform.position.x - 10, transform.position.y - 1.6f);

            if (random > 9 && random <= 99) //십의 자리일 때
            {
                num1.transform.position = new Vector2(transform.position.x + dis, transform.position.y + dis3);
            }
            else if (random > 0 && random <= 9) //일의 자리일 때
            {
                num1.transform.position = new Vector2(transform.position.x, transform.position.y + dis3);
            }
            num2.transform.position = new Vector3(num1.transform.position.x - 2 * dis, num1.transform.position.y, -1);

            hpbar1.transform.position = new Vector2(transform.position.x - dis1, transform.position.y + dis2);
            hpbar2.transform.position = new Vector2(transform.position.x, transform.position.y + dis2);
            hpbar3.transform.position = new Vector2(transform.position.x + dis1, transform.position.y + dis2);
        }

        if (heart == 0) //UI 삭제
        {
            Destroy(ef1);
            Destroy(ef2);

            Destroy(num1);
            Destroy(num2);

            Destroy(hpbar1);
            Destroy(hpbar2);
            Destroy(hpbar3);
        }
    }

    public void Layer()
    {
        SpriteRenderer spriteM = GetComponent<SpriteRenderer>();
        if (monnum == 1)
        {
            spriteM.sortingOrder = -7;
            ef1.GetComponent<LayerScript>().monnum = 1;
            ef2.GetComponent<LayerScript>().monnum = 1;
            num1.GetComponent<LayerScript>().monnum = 1;
            num2.GetComponent<LayerScript>().monnum = 1;
            hpbar1.GetComponent<LayerScript>().monnum = 1;
            hpbar2.GetComponent<LayerScript>().monnum = 1;
            hpbar3.GetComponent<LayerScript>().monnum = 1;
            ef1.GetComponent<LayerScript>().eLayer();
            ef2.GetComponent<LayerScript>().eLayer();
            num1.GetComponent<LayerScript>().Layer();
            num2.GetComponent<LayerScript>().Layer();
            hpbar1.GetComponent<LayerScript>().Layer();
            hpbar2.GetComponent<LayerScript>().Layer();
            hpbar3.GetComponent<LayerScript>().Layer();
        }
        else if(monnum == 2)
        {
            spriteM.sortingOrder = -3;
            ef1.GetComponent<LayerScript>().monnum = 2;
            ef2.GetComponent<LayerScript>().monnum = 2;
            num1.GetComponent<LayerScript>().monnum = 2;
            num2.GetComponent<LayerScript>().monnum = 2;
            hpbar1.GetComponent<LayerScript>().monnum = 2;
            hpbar2.GetComponent<LayerScript>().monnum = 2;
            hpbar3.GetComponent<LayerScript>().monnum = 2;
            ef1.GetComponent<LayerScript>().eLayer();
            ef2.GetComponent<LayerScript>().eLayer();
            num1.GetComponent<LayerScript>().Layer();
            num2.GetComponent<LayerScript>().Layer();
            hpbar1.GetComponent<LayerScript>().Layer();
            hpbar2.GetComponent<LayerScript>().Layer();
            hpbar3.GetComponent<LayerScript>().Layer();
        }
        else if(monnum == 3)
        {
            spriteM.sortingOrder = -5;
            ef1.GetComponent<LayerScript>().monnum = 3;
            ef2.GetComponent<LayerScript>().monnum = 3;
            num1.GetComponent<LayerScript>().monnum = 3;
            num2.GetComponent<LayerScript>().monnum = 3;
            hpbar1.GetComponent<LayerScript>().monnum = 3;
            hpbar2.GetComponent<LayerScript>().monnum = 3;
            hpbar3.GetComponent<LayerScript>().monnum = 3;
            ef1.GetComponent<LayerScript>().eLayer();
            ef2.GetComponent<LayerScript>().eLayer();
            num1.GetComponent<LayerScript>().Layer();
            num2.GetComponent<LayerScript>().Layer();
            hpbar1.GetComponent<LayerScript>().Layer();
            hpbar2.GetComponent<LayerScript>().Layer();
            hpbar3.GetComponent<LayerScript>().Layer();
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

    void Tremble() //덜덜 함수
    {
        CancelInvoke("Stop");
        move = false;
        x0 = gameObject.transform.position.x;
        x1 = x0 + 0.1f;
        tremble = true;

        Invoke("Stop", 0.35f);
    }

    public void OnDamaged() //피격 함수
    {
        heart--;
        animator.SetInteger("hit", heart); //애니
        if (heart != 0)
        {
            dis4 = transform.position.x + 4;
            move = false;
            movey = 5;
            damaged = true;

            Invoke("Stop", 3f);
            HeartMaker();
            setting();
        }
        else
        {
            move = false;
            movey = 6;
            damaged = true;

            Invoke("Inactive", 1.5f);
        }
    }

    void Stop()
    {
        move = true;
        movey = 1;
        tremble = false;
        damaged = false;
    }

    void Attack() //공격 함수
    {
        GameObject.Find("Player").GetComponent<PlayerScript>().heart -= 1;
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hurt2");
        animator.SetTrigger("attack");
        ef1.GetComponent<Animator>().SetTrigger("effect1");
        ef2.GetComponent<Animator>().SetTrigger("effect2");

        Invoke("reAttack", 2f);
    }

    void reAttack() //공격 재개 함수
    {
        attack = false;
    }

    void Inactive() //죽음 처리 함수
    {
        Destroy(gameObject);
        GameObject.Find("Stage").GetComponent<Stage>().remain -= 1;
    }
}