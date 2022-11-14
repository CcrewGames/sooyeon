using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonScript2 : MonoBehaviour
{
    //Time.unscaledDeltaTime

    bool move;
    float speed1 = 0.2f;
    float y0;
    float y1;

    public float myTimeScale = 1f;
    float myDeltaTime;

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
        move = false;
        y0 = transform.position.y;
        y1 = y0 - 0.1f;
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

        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target == this.gameObject)
            {
                GameObject.Find("Story").GetComponent<Story2Script>().clickNextButton = true;
            }
        }
    }
}
