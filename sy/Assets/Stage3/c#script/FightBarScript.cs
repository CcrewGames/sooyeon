using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBarScript : MonoBehaviour
{
    public int fighthbar;
    
    public GameObject fighthbarObject;

    void Start()
    {
        fighthbar = 5;
        fighthbarObject.GetComponent<Slider>().value = 5;
    }

    void Update() 
    {
        fighthbarObject.GetComponent<Slider>().value = fighthbar;

        if (fighthbarObject.GetComponent<Slider>().value >= 10)
            GameObject.Find("Stage").GetComponent<Stage3>().Win();

        if (fighthbarObject.GetComponent<Slider>().value <= 0)
            GameObject.Find("Stage").GetComponent<Stage3>().Lose();
    }
}
