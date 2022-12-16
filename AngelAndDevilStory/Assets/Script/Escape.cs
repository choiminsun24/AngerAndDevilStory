using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject escape;
    public GameObject helpness;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onFrame();
        }       
    }

    public void onFrame() //����â �ѱ�, �ڷ� ����
    {
        escape.SetActive(!escape.activeSelf);
    }

    public void goMenu() //�޴��� �̵�
    {
        SceneManager.LoadScene("Main");
    }

    public void End() //��������
    {
        Application.Quit();
    }

    public void onHelpness()
    {
        onFrame();
        helpness.SetActive(!helpness.activeSelf);
    }
}
