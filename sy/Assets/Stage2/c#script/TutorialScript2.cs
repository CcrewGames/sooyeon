using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript2 : MonoBehaviour
{
    public GameObject attackbar;
    public GameObject num1, num2;

    public GameObject background;
    GameObject background1;

    public GameObject balloon;
    public GameObject arrow;

    public GameObject canvas;
    public GameObject Text;
    public Text text;

    public List<string> sentences;

    int i;
    public bool nextbutton;

    void Start()
    {
        attackbar.SetActive(false);
        
        num1.SetActive(false);
        num2.SetActive(false);
        
        background1 = Instantiate(background, transform.position, transform.rotation);
        background1.SetActive(false);

        balloon.SetActive(false);
        arrow.SetActive(false);

        Text.SetActive(false);

        i = 0;
        nextbutton = false;

        sentences = new List<string>();
        sentences.Add("�̹����� ���� ���ڰ� �־����ϴ�.");
        sentences.Add("0���� ���� ���� ���� �� �����ϴ�.");
        sentences.Add("������� ����θ� �����մϴ�.");
    }

    void Update()
    {
        if (nextbutton == true)
        {
            if (i == 2)
            {
                SceneOff();
            }
            else
            {
                i++;
                Scene();
                nextbutton = false;
            }
        }
    }

    public void Scene()
    {
        if (i == 0)
        {
            GameObject.Find("Stage").GetComponent<Stage2>().PauseMode();
            GameObject.Find("Stage").GetComponent<Stage2>().MusicPauseMode();
            GameObject.Find("Stage").GetComponent<Stage2>().tutorial = true;

            attackbar.SetActive(true);

            num1.SetActive(true);
            num2.SetActive(true);

            background1.SetActive(true);

            balloon.SetActive(true);
            arrow.SetActive(true);

            Text.SetActive(true);
            
            text.text = sentences[i];
        }
        else if (i == 1)
        {
            text.text = sentences[i];
        }
        else if (i == 2)
        {
            text.text = sentences[i];
        }
    }

    void SceneOff()
    {
        GameObject.Find("Stage").GetComponent<Stage2>().ResumeMode();
        GameObject.Find("Stage").GetComponent<Stage2>().MusicResumeMode();
        GameObject.Find("Stage").GetComponent<Stage2>().tutorial = false;

        Destroy(gameObject);
        Destroy(canvas);
        Destroy(background1);
    }
}
