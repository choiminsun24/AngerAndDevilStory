using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    DialogueTrigger DT;

    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;
    public GameObject animObj;
    Animator anim;

    private string sentence;
    private bool displayAnim = false;

    Dialogue[] dia;
    private int num;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        DT = GetComponent<DialogueTrigger>();
        anim = animObj.GetComponent<Animator>();
    }

    public void setDialogue(Dialogue[] dia, int num, string sceneName) //대화 시작
    {
        this.num = num;
        this.sceneName = sceneName;
        this.dia = dia;

        thisDialogue(dia[num]);
    }

    public void thisDialogue(Dialogue dialog) //이번 배경에서의 대화
    {
        foreach (string str in dialog.sentences) //큐의 문장을 한 문장씩 넣어줌.
        {
            this.sentences.Enqueue(str);
        }

        nextButton();
    }

    public void nextButton() //대화 안에서 한 문장씩 꺼내어 보여주기.
    {
        if (sentences.Count == 0) //마지막 문장일 때
        {
            if (this.num == 0) //마지막 대화면 다음 씬으로 넘어간다.
                SceneManager.LoadScene(this.sceneName);
            else
                EndDialogue(); //마지막 대화가 아니면 다음 대화로 넘어간다.

            return;
        }

        StopAllCoroutines();
        StartCoroutine(Display(sentences.Dequeue()));
    }

    IEnumerator Display(string sentence) //문장을 보여줄 때 한 글자씩 보여주기
    {
        dialogueText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndDialogue() //다음 대화로 1.애니메이션 배경전환 2. 다음 대화 넣기
    {
        this.num--;
        setAnimation();
        thisDialogue(dia[this.num]);
    }

    void setAnimation()
    {
        if (displayAnim == true)
            displayAnim = false;
        else
            displayAnim = true;

        anim.SetBool("go", displayAnim);
    }
}