using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    AudioSource audioSource;/////////////소리

    public GameObject tutorials;

    public Image tutorialImage; //기존 이미지
    public Sprite TestSprite2;
    public Sprite TestSprite3;
    public Sprite TestSprite4;
    public Sprite TestSprite5;
    public Sprite TestSprite6;
    public Sprite TestSprite7;
    public Sprite TestSprite8;
    public Sprite TestSprite9;
    public Sprite TestSprite10;
    public Sprite TestSprite11;
    public Sprite TestSprite12;
    int tuNum = 1;
    bool istuto = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();/////////////소리
        tutorials.SetActive(false);
    } 

    public void tutorialstart(){
        tutorials.SetActive(true);
        GameObject.Find("Stage").GetComponent<Stage>().MusicPauseMode();;
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
        }else if (tuNum == 2){
            tutorialImage.sprite = TestSprite3;
            tuNum += 1;
        }else if (tuNum == 3){
            tutorialImage.sprite = TestSprite4;
            tuNum += 1;
        }else if (tuNum == 4){
            tutorialImage.sprite = TestSprite5;
            tuNum += 1;
        }else if (tuNum == 5){
            tutorialImage.sprite = TestSprite6;
            tuNum += 1;
        }else if (tuNum == 6){
            tutorialImage.sprite = TestSprite7;
            tuNum += 1;
        }else if (tuNum == 7){
            tutorialImage.sprite = TestSprite8;
            tuNum += 1;
        }else if (tuNum == 8){
            tutorialImage.sprite = TestSprite9;
            tuNum += 1;
        }else if (tuNum == 9){
            tutorialImage.sprite = TestSprite10;
            tuNum += 1;
        }else if (tuNum == 10){
            tutorialImage.sprite = TestSprite11;
            tuNum += 1;
        }else if (tuNum == 11){
            tutorialImage.sprite = TestSprite12;
            tuNum += 1;
        }else if (tuNum == 12){
            tutorials.transform.position = new Vector3 ( 0, 100, 0 ) ;
            GameObject.Find("Stage").GetComponent<Stage>().MusicResumeMode();
            audioSource.Play();
            tuNum += 1;
        }else{

        }
    }
}
