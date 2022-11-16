using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    public GameObject num1;
    public GameObject num2;

    public int result;
    
    void Start()
    {
        num1.SetActive(false);
        num2.SetActive(false);
    }

    void nummaker()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        int b = result / 10;
        int a = result % 10;
        SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
        spriteA.sprite = sprites[a];
        SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
        spriteB.sprite = sprites[b];

        num1.SetActive(true);
        num2.SetActive(true);
    }
}