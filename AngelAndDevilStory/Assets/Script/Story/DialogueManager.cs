using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public string Next;

    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, bool Last) //대화 시작
    {
        sentences.Clear(); //이전 대화 삭제
        foreach (string sentence in dialogue.sentences) //큐의 문장을 한 문장씩 넣어줌.
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(Last); //sentences에 담긴 문장을 한 글자씩 출력
    }

    public void DisplayNextSentence(bool Last)
    {
        if (sentences.Count == 0)
        {
            if (Last)
                EndScene();
            else
                EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
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
        //애니메이션 넣어서 다음 장면으로 넘기기
    }

    public void EndScene() //다음 씬으로
    {
        //게임으로 넘어가는 함수
    }


    // Update is called once per frame
    void Update()
    {

    }
}
