using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_player : MonoBehaviour
{
    public int healthbar;
    public int Image;
    
    public GameObject healthbarObject;

    public void healthbar_player()
    {
          GameObject[] players=GameObject.FindGameObjectsWithTag("Player");
          healthbar= players[0].GetComponent<PlayerScript>().heart;
          healthbarObject.GetComponent<Slider>().value= healthbar;

    }
    void Start()
    {
        
    }

    void Update() 
    {
            healthbar_player();
    }

}
