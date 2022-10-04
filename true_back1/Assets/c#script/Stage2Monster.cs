using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Monster : MonoBehaviour
{
    Rigidbody2D rigid;

    int heart = 4; //임의 체력 변수
    bool move = true; //움직임 변수
    public int random;
    private GameObject target;
    public GameObject punch;

    void Start()
    {
        setting();
    }

    void setting()
    {
        random = Random.Range(1, 10);
        Debug.Log(random);
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (move == true)
            rigid.velocity = new Vector2(-2, rigid.velocity.y);
    }

    public void Update() //주인공에게 공격받았을 때
    {
        if (heart == 0)
        {
            Destroy(gameObject);
            GameObject.Find("Stage").GetComponent<Stage>().Remain();
        }

        if (random == punch.GetComponent<PunchScript>().pun)
        {
            OnDamaged();
            setting();
            heart--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Attack();
        }
    }

    void OnDamaged() //피격
    {
        CancelInvoke("Stop");
        move = false;
        rigid.velocity = Vector2.zero;
        Vector2 JumpVelocity = new Vector2(5, 5);
        rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);
        punch.GetComponent<PunchScript>().pun = 0;

        Invoke("Stop", 2f); //2초 스턴
    }

    void Attack() //공격(몸빵)
    {
        move = false;
        rigid.velocity = Vector2.zero;
        Vector2 JumpVelocity = new Vector2(3, 4);
        rigid.AddForce(JumpVelocity, ForceMode2D.Impulse);
        GameObject.Find("Player").GetComponent<PlayerScript>().Attack1();

        Invoke("Stop", 1f); //1초 스턴
    }

    void Stop() //스턴 함수
    {
        move = true;
    }
}
