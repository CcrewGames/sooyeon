using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int heart;
    float speed = 5f;
    int move = 0;
    float pos1 = -7;
    public Animator animator;

    void Start()
    {
        heart = 100;
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (transform.position.x - pos1 <= 7 && move == 1)
            Run();

        if (transform.position.x >= -7 && move == 2)
            Re();

        if (heart == 0)
        {
            Destroy(gameObject);
            GameObject.Find("Stage").GetComponent<Stage>().Fail();
        }
    }

    void Run()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        animator.SetBool("fight", true);
        
    }

    void Re()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        animator.SetBool("fight", true);
    }

    public void Inv1()
    {
        move = 1;
        Invoke("Inv2", 5f);
    }

    public void Inv2()
    {
        move = 2;
        Invoke("Inv3", 5f);
    }

    public void Inv3()
    {
        GameObject.Find("Stage").GetComponent<Stage>().StageMove();
        animator.SetBool("fight", false);
    }

    public void Attack1()
    {
        heart -= 5;
    }

    public void Attack2()
    {
        heart -= 10;
    }

    public void Attack3()
    {
        heart -= 15;
    }
}

