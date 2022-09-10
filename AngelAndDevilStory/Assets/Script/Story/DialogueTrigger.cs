using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public bool lastDialogue = false; //마지막 대화인지 여부. 다음 씬으로 갈지, 다음 대화로 갈지를 결정.

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
