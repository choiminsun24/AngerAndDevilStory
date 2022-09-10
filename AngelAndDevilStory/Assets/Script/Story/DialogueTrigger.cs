using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public bool lastDialogue = false; //������ ��ȭ���� ����. ���� ������ ����, ���� ��ȭ�� ������ ����.

    public Dialogue dia;
    public TextMeshProUGUI Text;
    private GameObject Score;

    public void Trigger()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dia, lastDialogue);
    }

    void Start()
    {
        Invoke("Trigger", 1f);
    }
}
