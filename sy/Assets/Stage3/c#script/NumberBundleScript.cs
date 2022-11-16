using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBundleScript : MonoBehaviour
{
    public GameObject timebox;
    public GameObject timecount;
    public GameObject attacknumber;
    public GameObject bundle;

    public int fortime;

    float x1;

    private GameObject target; //마우스 클릭 확인용 변수
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

    void Start()
    {
        timebox.SetActive(false);
        timecount.SetActive(false);
        bundle.SetActive(false);
        fortime = 0;
    }

    void Update()
    {

    }

    public void numbunOn()
    {
        timebox.SetActive(true);
        timecount.SetActive(true);
        bundle.SetActive(true);

        fortime = 1;
    }

    public void numbunOff()
    {
        fortime = 1;
    }
}
