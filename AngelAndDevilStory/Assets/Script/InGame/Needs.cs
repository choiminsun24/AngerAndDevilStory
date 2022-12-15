using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Needs : MonoBehaviour
{
    public int need;
    public TextMeshProUGUI ment;

    private float timer = 0.0f;

    private Color clr;
    private Image img;
    private ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ScoreObject = GameObject.FindWithTag("Score");
        score = ScoreObject.GetComponent<ScoreManager>();
        img = GetComponent<Image>();
        clr = img.color;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2.0f)
        {
            score.subScoreDisappear();
            Destroy(gameObject);
        }
    }
    
    public void clicked()
    {
        if (Player.get_Player() == need)
        {
            ment.text = "감사합니다!";
            StartCoroutine(correct());
            score.addScore();
        }
        else
        {
            StartCoroutine(fail());
            ment.text = "오, 이런...!";
            score.subScore();
        }
    }

    private IEnumerator fail() //실패했을 때 버튼이 빨개짐.
    {
        while(img.color.g > 0.5)
        {
            clr.g -= Time.deltaTime*2;
            clr.b = clr.g;
            img.color = clr;
            yield return null;
        }
        
        while(img.color.g < 1)
        {
            clr.g += Time.deltaTime*2;
            clr.b = clr.g;
            img.color = clr;
            yield return null;
        }

        ment.text = "";
        yield break;
    }

    private IEnumerator correct() //성공
    {
        while (img.color.a > 0)
        {
            clr.a -= Time.deltaTime*2;
            img.color = clr;
            yield return null;
        }

        Destroy(gameObject);
        yield break;
    }
}
