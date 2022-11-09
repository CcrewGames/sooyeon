using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1BossScript : MonoBehaviour
{
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

    public bool skill1;
    bool skill2;
    bool damaged;

    public int random;

    //���� ǥ�� ����
    public GameObject number;
    private GameObject num1; //���� �ڸ�
    private GameObject num2; //���� �ڸ�
    float dis = 0.2f;

    private GameObject target; //���콺 Ŭ�� Ȯ�ο� ����

    public GameObject bomb;
    GameObject bom;

    public float timemax = 10f;
    public float time1;
    bool timer;

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
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == random) //���� = ��� ��ġ
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

        if (random > 9 && random <= 99) //���� �ڸ��� ��
        {
            num1.transform.position = new Vector2(bom.transform.position.x + dis, bom.transform.position.y);
        }
        else if (random > 0 && random <= 9) //���� �ڸ��� ��
        {
            num1.transform.position = new Vector2(bom.transform.position.x, bom.transform.position.y);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);
    }

    private void setting1() //���� ����
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

    void Die() //���� ó�� �Լ�
    {
        Destroy(gameObject);
        Destroy(bom);
        Destroy(num1);
        Destroy(num2);
        GameObject.Find("Stage").GetComponent<Stage>().remain -= 1;
        GameObject.Find("Stage").GetComponent<Stage>().bossdie = true;
    }
}
