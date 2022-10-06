using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dia = new Dialogue[2];
    public int numDialog = 1;

    public void Trigger()
    {
        FindObjectOfType<DialogueManager>().setDialogue(dia, numDialog, "inGame1");
        if (numDialog == 0)
        {
            Debug.Log("³¡");
            return;
        }
            
        numDialog--;
    }

    void Start()
    {
        Invoke("Trigger", 1f);
    }
}
