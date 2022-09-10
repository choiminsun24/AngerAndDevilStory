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

    public void StartDialogue(Dialogue dialogue, bool Last) //��ȭ ����
    {
        sentences.Clear(); //���� ��ȭ ����
        foreach (string sentence in dialogue.sentences) //ť�� ������ �� ���徿 �־���.
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(Last); //sentences�� ��� ������ �� ���ھ� ���
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

    public void EndDialogue() //���� ��ȭ��
    {
        //�ִϸ��̼� �־ ���� ������� �ѱ��
    }

    public void EndScene() //���� ������
    {
        //�������� �Ѿ�� �Լ�
    }


    // Update is called once per frame
    void Update()
    {

    }
}
