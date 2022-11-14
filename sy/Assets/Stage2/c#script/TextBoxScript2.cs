using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxScript2 : MonoBehaviour
{
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

    void Update()
    {
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
