using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2BossScript : MonoBehaviour
{
    public Animator animator;

    public int heart; //���� ü��

    private bool move;
    private int movey; //���� �̵� ����2
    private bool tremble; //���� �������� ����

    //���� �̵� ����
    float speed;
    public float xm;

    //���� �������� ����
    float speed2 = 5f;
    float time;
    float x0;
    float x1;

    public int random;

    //���� ǥ�� ����
    public GameObject number;
    private GameObject num1; //���� �ڸ�
    private GameObject num2; //���� �ڸ�
    float dis = 0.3f;

    public bool skill1;
    public bool skill2;
    bool damaged;

    public GameObject bomb;
    public GameObject bom;
    public Image bombtimer;

    public float timemax = 10f;
    public float time1;
    bool timer;

    public GameObject e7;
    private GameObject ef7;

    //��ź
    int bombmove; //0 �⺻, 1 ��ȯ, 2 ����, 3 �ǰ�
    float speed3 = 4f;
    float speed4 = 7f;

    private GameObject target; //���콺 Ŭ�� Ȯ�ο� ����
    void CastRay() //���콺 Ŭ�� Ȯ�ο� �Լ�
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }

    void Start() //����
    {
        animator = GetComponent<Animator>();

        heart = 5;

        xm = 7f;
        move = false;
        speed = 2f;
        movey = 1;
        tremble = false;

        skill1 = true;
        skill2 = false;
        damaged = true;

        bombmove = 0;
        timer = false;
        time1 = timemax;

        ef7 = Instantiate(e7, transform.position, transform.rotation);

        bom = Instantiate(bomb, new Vector2(transform.position.x, -2), transform.rotation);
        num1 = Instantiate(number, new Vector2(bom.transform.position.x - dis, bom.transform.position.y), transform.rotation);
        num2 = Instantiate(number, new Vector2(bom.transform.position.x, bom.transform.position.y), transform.rotation);

        bom.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);
    }

    public void Run() //������
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

        if (movey == 4) //��������
            transform.position = new Vector2(transform.position.x - speed2 * Time.deltaTime, transform.position.y);
        else if (movey == 5) //��������
            transform.position = new Vector2(transform.position.x + speed2 * Time.deltaTime, transform.position.y);

        if (random > 9 && random <= 99) //���� �ڸ��� ��
        {
            num1.transform.position = new Vector2(bom.transform.position.x + dis, bom.transform.position.y);
        }
        else if (random > 0 && random <= 9) //���� �ڸ��� ��
        {
            num1.transform.position = new Vector2(bom.transform.position.x, bom.transform.position.y);
        }
        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        ef7.transform.position = new Vector2(transform.position.x - 5f, transform.position.y);

        if (bombmove == 1)
            bom.transform.position = Vector3.Slerp(bom.transform.position, new Vector2(2.4f, 0), Time.deltaTime * speed3);

        if (bombmove == 2)
            bom.transform.position = Vector3.Lerp(bom.transform.position, new Vector2(-4f, -1), Time.deltaTime * speed4);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Stage").GetComponent<Stage2>().pausemode == false)
        {
            CastRay();

            if ((target == num1 || target == num2 || target == bom) && GameObject.Find("Punch").GetComponent<PunchScript2>().punchmode == 1 && timer == true)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript2>().result == random && time1 > 0) //���� = ��� ��ġ
                {
                    timer = false;

                    GameObject.Find("Stage").GetComponent<Stage2>().xf = bom.transform.position.x;
                    GameObject.Find("Stage").GetComponent<Stage2>().yf = bom.transform.position.y;

                    GameObject.Find("Stage").GetComponent<Stage2>().Fly1();

                    GameObject.Find("Punch").GetComponent<PunchScript2>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript2>().PunchMode();

                    GameObject.Find("Stage").GetComponent<Stage2>().BombOff();
                }
            }
        }

        if (tremble == true)
        {
            if (transform.position.x >= x1)
                movey = 4;
            else if (transform.position.x <= x0)
                movey = 5;
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
            Invoke("story2_2", 1.5f);
            Invoke("Skill_2", 2f);
            damaged = true;
        }
        if (heart == 0 && damaged == false)
        {
            Invoke("story3", 1.5f);
            Invoke("Die", 3f);
            damaged = true;
        }

        if (skill1 == false && skill2 == false && GameObject.Find("Stage").GetComponent<Stage2>().remain == 1)
        {
            bom.transform.position = new Vector2(transform.position.x, -2);
            Invoke("Skill_2", 2f);
            damaged = false;
            skill2 = true;
        }

        if (bombmove == 1 && bom.transform.position.x <= 2.5f)
        {
            timer = true;
            setting();
            bom.GetComponent<Animator>().SetTrigger("bomb");
            bombmove = 0;
        }
        if (bombmove == 2 && bom.transform.position.x <= -3.9f)
        {
            bom.GetComponent<Animator>().SetTrigger("bombdestroy");
            Invoke("Attack", 0.47f);
            bombmove = 0;
        }

        if (timer == true)
        {
            time1 -= Time.deltaTime;
            GameObject.Find("Stage").GetComponent<Stage2>().BombTimer();
            GameObject.Find("Stage").GetComponent<Stage2>().xb = bom.transform.position.x;
            GameObject.Find("Stage").GetComponent<Stage2>().yb = bom.transform.position.y;
            GameObject.Find("Stage").GetComponent<Stage2>().BombPosition();
        }

        if (time1 <= 0.3f)
        {
            Invoke("Attackready", 0.15f);
            ef7.GetComponent<Animator>().SetTrigger("effect7");
            num1.SetActive(false);
            num2.SetActive(false);
            GameObject.Find("Stage").GetComponent<Stage2>().BombOff();
            time1 = timemax;
            timer = false;
        }

        if (heart >= 0 && GameObject.Find("Stage").GetComponent<Stage2>().fortime == 1)
        {
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar = heart;
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar_boss();
        }
    }

    private void setting() //���� ����
    {
        random = Random.Range(1, 10);
        nummaker();
    }

    void nummaker()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99) //���� �ڸ��� ��
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
        else if (random > 0 && random <= 9) //���� �ڸ��� ��
        {
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[random];

            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    void Tremble() //���� �Լ�
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
        transform.position = new Vector2(x0, transform.position.y);
        tremble = false;
    }

    void Skill_1()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().Boss1Skill();
    }
    void Skill_2()
    {
        bom.SetActive(true);
        bombmove = 1;
    }

    void Attackready()
    {
        bombmove = 2;
        animator.SetTrigger("stage2bossattack");
    }
    void Attack()
    {
        GameObject.Find("Player").GetComponent<PlayerScript2>().heart -= 10;
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hit");
        GameObject.Find("Punch").GetComponent<PunchScript2>().re();
        GameObject.Find("Punch").GetComponent<PunchScript2>().ScrollChange2();

        bom.transform.position = new Vector2(transform.position.x, -2);
        bom.SetActive(false);

        Invoke("Skill_2", 1f);
    }

    public void OnDamaged()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        bom.GetComponent<Animator>().SetTrigger("bombdestroy");
        Invoke("realOnDamaged", 0.46f);
    }
    void realOnDamaged()
    {
        bom.transform.position = new Vector2(transform.position.x, -2);
        bom.SetActive(false);

        Tremble();
        time1 = timemax;
        animator.SetTrigger("stage2bosshit");
        heart--;
        damaged = false;
    }

    void story2_2()
    {
        GameObject.Find("Story").GetComponent<Story2Script>().Story2_2On();
    }
    void story3()
    {
        GameObject.Find("Story").GetComponent<Story2Script>().Story3On();
    }

    void Die() //���� ó�� �Լ�
    {
        GameObject.Find("Stage").GetComponent<Stage2>().BossHealthbarOff();
        GameObject.Find("Stage").GetComponent<Stage2>().remain -= 1;
        Destroy(gameObject);
        Destroy(bom);
        Destroy(num1);
        Destroy(num2);

        GameObject.Find("Player").GetComponent<PlayerScript2>().xb = transform.position.x;
        GameObject.Find("Player").GetComponent<PlayerScript2>().yb = transform.position.y;
        GameObject.Find("Player").GetComponent<PlayerScript2>().bm();
    }
}
