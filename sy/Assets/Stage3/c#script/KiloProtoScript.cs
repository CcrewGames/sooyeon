using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiloProtoScript : MonoBehaviour
{
    bool move;
    float speed1 = 0.2f;
    float y0;
    float y1;

    public float myTimeScale = 1f;
    float myDeltaTime;

    public GameObject e;
    GameObject ef;
    public GameObject e2;

    void Start()
    {
        move = false;
        y0 = transform.position.y;
        y1 = y0 - 0.1f;

        ef = Instantiate(e, transform.position, transform.rotation);
    }

    void FixedUpdate()
    {
        ef.transform.position = transform.position;
    }

    void Update()
    {
        myDeltaTime = Time.unscaledDeltaTime * myTimeScale;

        if (transform.position.y <= y1)
            move = false;
        else if (transform.position.y >= y0)
            move = true;

        if (move == false)
            transform.position = transform.position + transform.up * speed1 * myDeltaTime;
        else if (move == true)
            transform.position = transform.position - transform.up * speed1 * myDeltaTime;
    }

    public void twingkle()
    {
        ef.GetComponent<Animator>().SetBool("effect1", true);
    }

    public void Boom()
    {
        e2.GetComponent<Animator>().SetBool("effect2", true);
    }
}
