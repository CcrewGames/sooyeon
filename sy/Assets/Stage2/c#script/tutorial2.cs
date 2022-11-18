using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial2 : MonoBehaviour
{
    AudioSource audioSource;/////////////소리
    public GameObject tutorials;

    public Image tutorialImage; //기존 이미지
    public Sprite TestSprite2;

    int tuNum = 1;
    bool istuto = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();/////////////소리
        tutorials.SetActive(false);
    } 

    public void tutorialstart(){
        tutorials.SetActive(true);
        GameObject.Find("Stage").GetComponent<Stage2>().MusicPauseMode();
        istuto = true;
    }

    void Update()
    {
        if (istuto){
            if (Input.GetMouseButtonDown(0)) {
                gotutorial();
            }
        }
    }

    public void gotutorial(){
        if (tuNum == 1){
            tutorialImage.sprite = TestSprite2;
            tuNum += 1;
        }else if(tuNum == 2){
            tutorials.transform.position = new Vector3 ( 0, 100, 0 ) ;
            GameObject.Find("Stage").GetComponent<Stage2>().MusicResumeMode();
            audioSource.Play();
            tuNum += 1;
        }else{

        }
    }
}
