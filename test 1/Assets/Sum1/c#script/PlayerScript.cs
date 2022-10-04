using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int heart;
    float speed = 4f;
    public Animator animator;
    public GameObject punch;
    public int random;

    public GameObject number;
    private GameObject num1;
    private GameObject num2;
    float dis = 0.35f;

    private GameObject target;

    bool healmode;

    void CastRay()
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
        }
    }

    void setting()
    {
        random = Random.Range(1, 15);
        nummaker();
    }

    void nummaker()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99)
        {
            int a = random / 10;
            int b = random % 10;
            num1 = Instantiate(number, new Vector2(transform.position.x - dis, transform.position.y + 2), transform.rotation);
            num2 = Instantiate(number, new Vector2(transform.position.x + dis, transform.position.y + 2), transform.rotation);
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[a];
            SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
            spriteB.sprite = sprites[b];
        }
        else if (random > 0 && random <= 9)
        {
            num1 = Instantiate(number, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
            SpriteRenderer spriteR = num1.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprites[random];
        }
    }

    void Start()
    {
        move = 0;
        healmode = false;
        heart = 100;
        animator = GetComponent<Animator>();
    }

    public int move;
    void Update()
    {
        if (move == 1)
            Run();

        if (move == 2)
            Re();

        if (heart == 0)
        {
            Destroy(gameObject);
            GameObject.Find("Stage").GetComponent<Stage>().Fail();
        }

        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target == this.gameObject && healmode == false)
            {
                healmode = true;
                setting();
            }
            else if (target == this.gameObject && healmode == true)
            {
                if (punch.GetComponent<PunchScript>().result == random)
                {
                    heart += random;
                    if (random > 9 && random <= 99)
                    {
                        Destroy(num1);
                        Destroy(num2);
                    }
                    else if (random > 0 && random <= 9)
                    {
                        Destroy(num1);
                    }
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                else
                {
                    Debug.Log("다시");
                    if (random > 9 && random <= 99)
                    {
                        Destroy(num1);
                        Destroy(num2);
                    }
                    else if (random > 0 && random <= 9)
                    {
                        Destroy(num1);
                    }
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                }
                healmode = false;
            }
        }
    }

    void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("fight", true);
        Invoke("Re", 5f);
    }

    void Re()
    {
        move = 2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-7, transform.position.y, 0), Time.deltaTime * speed);
        animator.SetBool("fight", true);
        Invoke("Next", 5f);
    }

    public void Next()
    {
        move = 0;
        animator.SetBool("fight", false);
    }

    public void Attack1()
    {
        heart -= 0;
    }

    public void Attack2()
    {
        heart -= 0;
    }

    public void Attack3()
    {
        heart -= 0;
    }
}

