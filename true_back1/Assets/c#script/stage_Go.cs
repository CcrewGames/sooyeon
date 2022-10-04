using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_Go : MonoBehaviour
{
    // Start is called before the first frame update

    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("sky");
    }
    
}
