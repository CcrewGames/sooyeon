using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingscene3 : MonoBehaviour
{   
    public GameObject BackgroundMusic;
    AudioSource backmusic;

    public void Start() //게임 시작 초기화
    {
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
    }

    public void endingStart()
    {
        backmusic.Pause();
        Debug.Log("끝~");
    }
}
  
  