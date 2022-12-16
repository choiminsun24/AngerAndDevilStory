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

    public void onFrame() //선택창 켜기, 뒤로 가기
    {
        escape.SetActive(!escape.activeSelf);
    }

    public void goMenu() //메뉴로 이동
    {
        SceneManager.LoadScene("Main");
        onFrame();
    }

    public void End() //게임종료
    {
        Application.Quit();
    }

    public void onHelpness()
    {
        onFrame();
        helpness.SetActive(!helpness.activeSelf);
    }
}
