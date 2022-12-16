using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject escape;
    public GameObject helpness;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

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
        onFrame();
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
