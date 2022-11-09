using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerScript : MonoBehaviour
{
    public int monnum;

    public void Layer()
    {
        SpriteRenderer spriteM = GetComponent<SpriteRenderer>();
        if (monnum == 1)
        {
            spriteM.sortingOrder = -7;
        }
        else if (monnum == 2)
        {
            spriteM.sortingOrder = -3;
        }
        else if (monnum == 3)
        {
            spriteM.sortingOrder = -5;
        }
    }

    public void eLayer()
    {
        SpriteRenderer spriteM = GetComponent<SpriteRenderer>();
        if (monnum == 1)
        {
            spriteM.sortingOrder = -6;
        }
        else if (monnum == 2)
        {
            spriteM.sortingOrder = -2;
        }
        else if (monnum == 3)
        {
            spriteM.sortingOrder = -4;
        }
    }
}
