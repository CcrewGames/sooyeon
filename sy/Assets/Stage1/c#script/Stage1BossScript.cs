using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1BossScript : MonoBehaviour
{
    public int heart; //몬스터 체력

    private bool move;
    private int movey; //몬스터 이동 변수2
    private bool tremble; //몬스터 ㅂㄷㅂㄷ 변수

    //몬스터 이동 관련
    float speed;
    public float xm;

    //몬스터 ㅂㄷㅂㄷ 관련
    float speed2 = 5f;
    float time;
    float x0;
    float x1;

    public bool skill1;
    bool skill2;
    bool damaged;

    public int random;

    //난수 표시 관련
    public GameObject number;
    private GameObject num1; //일의 자리
    private GameObject num2; //십의 자리
    float dis = 0.2f;

    private GameObject target; //마우스 클릭 확인용 변수

    public GameObject bomb;
    GameObject bom;

    public float timemax = 10f;
    public float time1;
    bool timer;

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
        xm = 7f;
        move = false;
        speed = 2f;
        movey = 1;
        tremble = false;

        time1 = timemax;

        heart = 5;

        skill1 = true;
        skill2 = false;
        damaged = true;

        timer = false;

        bom = Instantiate(bomb, new Vector2(0, 0), transform.rotation);
        num1 = Instantiate(number, new Vector2(bom.transform.position.x - dis, bom.transform.position.y), transform.rotation);
        num2 = Instantiate(number, new Vector2(bom.transform.position.x, bom.transform.position.y), transform.rotation);

        num1.SetActive(false);
        num2.SetActive(false);
        bom.SetActive(false);
    }

    public void Run() //리스폰
    {
        speed = 5f;
        move = true;
    }

    void FixedUpdate()
    {
        if (transform.position.x > xm && move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xm, transform.position.y), Time.deltaTime * speed);
        }

        if (movey == 4) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x - speed2 * Time.deltaTime, transform.position.y);
        else if (movey == 5) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x + speed2 * Time.deltaTime, transform.position.y);
    }

    public void Update()
    {
        if (tremble == true)
        {
            if (transform.position.x >= x1)
                movey = 4;
            else if (transform.position.x <= x0)
                movey = 5;
        }

        if (heart == 5 && damaged == false)
        {
            Invoke("setting1", 1f);
            damaged = true;
        }

        if (heart == 4 && damaged == false)
        {
            Invoke("setting1", 1f);
            damaged = true;
        }

        if (heart == 3 && damaged == false)
        {
            Invoke("setting1", 1f);
            damaged = true;
        }

        if (heart == 2 && damaged == false)
        {
            Invoke("setting1", 1f);
            damaged = true;
        }
        
        if (heart == 1 && damaged == false)
        {
            Invoke("setting1", 1f);
            damaged = true;
        }
        
        if (heart == 0 && damaged == false)
        {
            Invoke("Die", 2f);
            damaged = true;
        }

        if (skill1 == false && skill2 == false && GameObject.Find("Stage").GetComponent<Stage>().remain == 1)
        {
            Invoke("Skill_2", 2f);
            damaged = false;
            skill2 = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if ((target == num1 || target == num2 || target == bom) && GameObject.Find("Punch").GetComponent<PunchScript>().punchmode == 1)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == random) //난수 = 결과 일치
                {
                    OnDamaged();

                    num1.SetActive(false);
                    num2.SetActive(false);
                    bom.SetActive(false);
                }
            }
        }

        if (timer == true)
        {
            time1 -= Time.deltaTime;
        }

        if(time1 <= 0)
        {
            Attack();
            time1 = timemax;
        }

        if (random > 9 && random <= 99) //십의 자리일 때
        {
            num1.transform.position = new Vector2(bom.transform.position.x + dis, bom.transform.position.y);
        }
        else if (random > 0 && random <= 9) //일의 자리일 때
        {
            num1.transform.position = new Vector2(bom.transform.position.x, bom.transform.position.y);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);
    }

    private void setting1() //난수 설정
    {
        random = Random.Range(1, 30);
        bom.SetActive(true);
        bom.GetComponent<Bomb>().Re();
        nummaker();
        timer = true;
    }

    void nummaker()
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

    void Tremble() //덜덜 함수
    {
        CancelInvoke("Stop");
        x0 = gameObject.transform.position.x;
        x1 = x0 + 0.1f;
        tremble = true;
        Invoke("Stop", 0.35f);
    }

    void Stop()
    {
        movey = 1;
        tremble = false;
    }

    void Skill_1()
    {
        GameObject.Find("Stage").GetComponent<Stage>().Boss1Skill();
    }

    void Skill_2()
    {
        bom.SetActive(true);
    }

    void Attack()
    {
        GameObject.Find("Punch").GetComponent<PunchScript>().re();
        GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
        GameObject.Find("Player").GetComponent<PlayerScript>().heart -= 5;
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hurt2");

        setting1();
    }

    void OnDamaged()
    {
        Tremble();
        time1 = timemax;
        GameObject.Find("Punch").GetComponent<PunchScript>().re();
        GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
        heart--;
        damaged = false;
    }

    void Die() //죽음 처리 함수
    {
        Destroy(gameObject);
        Destroy(bom);
        Destroy(num1);
        Destroy(num2);
        GameObject.Find("Stage").GetComponent<Stage>().remain -= 1;
        GameObject.Find("Stage").GetComponent<Stage>().bossdie = true;
    }
}
