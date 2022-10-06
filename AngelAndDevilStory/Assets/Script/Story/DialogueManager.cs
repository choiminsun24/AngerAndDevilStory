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

    public void setDialogue(Dialogue[] dia, int num, string sceneName) //��ȭ ����
    {
        this.num = num;
        this.sceneName = sceneName;
        this.dia = dia;

        thisDialogue(dia[num]);
    }

    public void thisDialogue(Dialogue dialog) //�̹� ��濡���� ��ȭ
    {
        foreach (string str in dialog.sentences) //ť�� ������ �� ���徿 �־���.
        {
            this.sentences.Enqueue(str);
        }

        nextButton();
    }

    public void nextButton() //��ȭ���� �� ����
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

    IEnumerator Display(string sentence) //������ ������ �� ���η� ����
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