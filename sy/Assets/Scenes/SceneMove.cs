using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();

            if (target == button1)
            {
                SceneManager.LoadScene(1);
            }
            else if (target == button2)
            {
                SceneManager.LoadScene(2);
            }
            else if (target == button3)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
