using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    //Find »ç¿ë
    public GameObject bom1, bom2, bom3, bom4, bom5, bom6, bom7, bom8;

    public float divide = 0;
    public float time = 100;

    public void Re()
    {
        bom1.SetActive(true);
        bom2.SetActive(true);
        bom3.SetActive(true);
        bom4.SetActive(true);
        bom5.SetActive(true);
        bom6.SetActive(true);
        bom7.SetActive(true);
        bom8.SetActive(true);
    }

    void Update() 
    {
        if (time <= divide * 7)
        {
            bom1.SetActive(true);
            bom2.SetActive(true);
            bom3.SetActive(true);
            bom4.SetActive(true);
            bom5.SetActive(true);
            bom6.SetActive(true);
            bom7.SetActive(true);
            bom8.SetActive(false);
        }

        if (time <= divide * 6)
        {
            bom1.SetActive(false);
            bom2.SetActive(true);
            bom3.SetActive(true);
            bom4.SetActive(true);
            bom5.SetActive(true);
            bom6.SetActive(true);
            bom7.SetActive(true);
            bom8.SetActive(false);
        }

        if (time <= divide * 5)
        {
            bom1.SetActive(false);
            bom2.SetActive(false);
            bom3.SetActive(true);
            bom4.SetActive(true);
            bom5.SetActive(true);
            bom6.SetActive(true);
            bom7.SetActive(true);
            bom8.SetActive(false);
        }

        if (time <= divide * 4)
        {
            bom1.SetActive(false);
            bom2.SetActive(false);
            bom3.SetActive(false);
            bom4.SetActive(true);
            bom5.SetActive(true);
            bom6.SetActive(true);
            bom7.SetActive(true);
            bom8.SetActive(false);
        }

        if (time <= divide * 3)
        {
            bom1.SetActive(false);
            bom2.SetActive(false);
            bom3.SetActive(false);
            bom4.SetActive(false);
            bom5.SetActive(true);
            bom6.SetActive(true);
            bom7.SetActive(true);
            bom8.SetActive(false);
        }

        if (time <= divide * 2)
        {
            bom1.SetActive(false);
            bom2.SetActive(false);
            bom3.SetActive(false);
            bom4.SetActive(false);
            bom5.SetActive(false);
            bom6.SetActive(true);
            bom7.SetActive(true);
            bom8.SetActive(false);
        }

        if (time <= divide * 1)
        {
            bom1.SetActive(false);
            bom2.SetActive(false);
            bom3.SetActive(false);
            bom4.SetActive(false);
            bom5.SetActive(false);
            bom6.SetActive(false);
            bom7.SetActive(true);
            bom8.SetActive(false);
        }

        if (time <= divide * 0)
        {
            bom1.SetActive(false);
            bom2.SetActive(false);
            bom3.SetActive(false);
            bom4.SetActive(false);
            bom5.SetActive(false);
            bom6.SetActive(false);
            bom8.SetActive(false);
            Invoke("off", divide);
        }
    }

    void off()
    {
        bom7.SetActive(false);
    }
}
