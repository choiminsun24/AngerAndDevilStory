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

    private string sentence;
    private bool displayAnim;

    Dialogue[] dia;
    private int num;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        DT = GetComponent<DialogueTrigger>();
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

    public void nextButton() //대화에서 한 문장
    {
        if (sentences.Count == 0)
        {
            if (this.num == 0)
                SceneManager.LoadScene(this.sceneName);
            else
                EndDialogue();

            return;
        }

        StopAllCoroutines();
        StartCoroutine(Display(sentences.Dequeue()));
    }

    IEnumerator Display(string sentence) //문장을 보여줄 때 도로록 쓰기
    {
        dialogueText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndDialogue() //다음 대화로
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
    }
}