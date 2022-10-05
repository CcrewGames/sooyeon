using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayerScript : MonoBehaviour
{
    public int healthbar;
    public int Image;
    
    public GameObject healthbarObject;

    public void healthbar_player()
    {
        healthbar = GameObject.Find("Player").GetComponent<PlayerScript>().heart;
        healthbarObject.GetComponent<Slider>().value = healthbar;
    }

    void Update() 
    {
        healthbar_player();
    }

}
