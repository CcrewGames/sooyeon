using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject Stage1Moster;
    public GameObject Stage2Moster;
    public GameObject Stage3Moster;

    public void Stage1Spawn()
    {
        for (int i=0; i<3; i++)
        {
            Instantiate( Stage1Moster, new Vector3(12+i,3,0), Stage1Moster.transform.rotation);
        }
    }

    public void Stage2Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Stage2Moster, new Vector3(12 + i, 3, 0),  Stage1Moster.transform.rotation);
        }
    }

    public void Stage3Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Stage3Moster, new Vector3(12 + i, 3, 0),  Stage1Moster.transform.rotation);
        }
    }
}
