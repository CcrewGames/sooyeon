using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2BossScript : MonoBehaviour
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
    public bool skill2;
    bool damaged;

    public int random;

    //난수 표시 관련
    public GameObject number;
    private GameObject num1; //일의 자리
    private GameObject num2; //십의 자리
    float dis = 0.3f;

    private GameObject target; //마우스 클릭 확인용 변수

    public GameObject bomb;
    public GameObject bom;
    public Image bombtimer;

    public float timemax = 10f;
    public float time1;
    public bool timer;

    //폭탄
    int bombmove; //0 기본, 1 소환, 2 공격, 3 피격
    float speed3 = 4f;
    float speed4 = 7f;

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

        bombmove = 0;

        bom = Instantiate(bomb, new Vector2(transform.position.x, -2), transform.rotation);
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

        if (bombmove == 1)
            bom.transform.position = Vector3.Slerp(bom.transform.position, new Vector2(3.4f, 0), Time.deltaTime * speed3);

        if (bombmove == 2)
            bom.transform.position = Vector3.Lerp(bom.transform.position, new Vector2(-4f, -1), Time.deltaTime * speed4);
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

        if (bombmove == 1 && bom.transform.position.x <= 3.5f)
        {
            timer = true;
            bombmove = 0;
        }
        if (bombmove == 2 && bom.transform.position.x <= -3.9f)
        {
            Attack();
            bombmove = 0;
        }

        if (heart == 4 && damaged == false)
        {
            Invoke("Skill_2", 1f);
            damaged = true;
        }
        if (heart == 3 && damaged == false)
        {
            Invoke("Skill_2", 1f);
            damaged = true;
        }
        if (heart == 2 && damaged == false)
        {
            Invoke("Skill_2", 1f);
            damaged = true;
        }
        if (heart == 1 && damaged == false)
        {
            Invoke("Skill_2", 1f);
            damaged = true;
        }
        if (heart == 0 && damaged == false)
        {
            Invoke("Die", 2f);
            damaged = true;
        }

        if (skill1 == false && skill2 == false && GameObject.Find("Stage").GetComponent<Stage2>().remain == 1)
        {
            bom.transform.position = new Vector2(transform.position.x, -2);
            Invoke("Skill_2", 2f);
            damaged = false;
            skill2 = true;
        }

        if (Input.GetMouseButtonDown(0) && GameObject.Find("Stage").GetComponent<Stage2>().pausemode == false)
        {
            CastRay();

            if ((target == num1 || target == num2 || target == bom) && GameObject.Find("Punch").GetComponent<PunchScript>().punchmode == 1)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == random && time1 > 0) //난수 = 결과 일치
                {
                    timer = false;

                    GameObject.Find("Stage").GetComponent<Stage2>().xf = bom.transform.position.x;
                    GameObject.Find("Stage").GetComponent<Stage2>().yf = bom.transform.position.y;

                    GameObject.Find("Stage").GetComponent<Stage2>().Fly1();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();

                    GameObject.Find("Stage").GetComponent<Stage2>().BombOff();
                }
            }
        }

        if (timer == true)
        {
            time1 -= Time.deltaTime;
            GameObject.Find("Stage").GetComponent<Stage2>().BombTimer();
            GameObject.Find("Stage").GetComponent<Stage2>().xb = bom.transform.position.x + 0.17f;
            GameObject.Find("Stage").GetComponent<Stage2>().yb = bom.transform.position.y;
            GameObject.Find("Stage").GetComponent<Stage2>().BombPosition();
        }

        if (time1 <= 0)
        {
            bombmove = 2;
            GameObject.Find("Stage").GetComponent<Stage2>().BombOff();
            time1 = timemax;
            timer = false;
        }

        if (random > 9 && random <= 99) //십의 자리일 때
        {
            num1.transform.position = new Vector2(bom.transform.position.x + dis + 0.15f, bom.transform.position.y);
        }
        else if (random > 0 && random <= 9) //일의 자리일 때
        {
            num1.transform.position = new Vector2(bom.transform.position.x + 0.15f, bom.transform.position.y);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        if (heart >= 0 && GameObject.Find("Stage").GetComponent<Stage2>().fortime == 1)
        {
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar = heart;
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar_boss();
        }
    }

    private void setting1() //난수 설정
    {
        random = Random.Range(1, 30);
        nummaker();
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
        GameObject.Find("Stage").GetComponent<Stage2>().Boss1Skill();
    }

    void Skill_2()
    {
        bom.SetActive(true);
        setting1();
        bombmove = 1;
    }

    void Attack()
    {
        GameObject.Find("Player").GetComponent<PlayerScript2>().heart -= 10;
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hurt2");
        GameObject.Find("Punch").GetComponent<PunchScript>().re();
        GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();

        bom.transform.position = new Vector2(transform.position.x, -2);
        num1.SetActive(false);
        num2.SetActive(false);
        bom.SetActive(false);

        Invoke("Skill_2", 1f);
    }

    public void OnDamaged()
    {
        bom.transform.position = new Vector2(transform.position.x, -2);
        num1.SetActive(false);
        num2.SetActive(false);
        bom.SetActive(false);

        Tremble();
        time1 = timemax;
        GameObject.Find("Punch").GetComponent<PunchScript>().re();
        GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
        heart--;
        damaged = false;
    }

    void Die() //죽음 처리 함수
    {
        GameObject.Find("Stage").GetComponent<Stage2>().BossHealthbarOff();
        Destroy(gameObject);
        Destroy(bom);
        Destroy(num1);
        Destroy(num2);
        GameObject.Find("Stage").GetComponent<Stage2>().remain -= 1;
        GameObject.Find("Stage").GetComponent<Stage2>().bossdie = true;
    }
}
