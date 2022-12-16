using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //스테이지 별로 다른 정보
    public int pointAdd; //1스테이지 10, 2스테이지 5, 3스테이지 5, 4스테이지 3점
    public int pointSub; //1스테이지 5, 2스테이지 10, 3스테이지 10, 4스테이지 15점
    const int DISAPPEARPOINT = 2;
    public int stage; //몇 스테이지인지 정보. 1스테이지는 2, 2스테이지는 3, 3스테이지는 5, 4스테이지면 0.

    public GameObject SpawnManager;
    public GameObject pop;
    public TextMeshProUGUI endingTXT;
    public TextMeshProUGUI scoreTXT;

    //공통 정보
    private int score = 20;

    void Start()
    {
        setScoreTXT();
    }

    public int getScore()
    {
        return score;
    }

    public void addScore()
    {
        score += pointAdd;
        setScoreTXT();
    }

    public void subScoreDisappear()
    {
        score -= DISAPPEARPOINT;

        if (stage == 5) //3스테이지에서는 그냥 지도록 함.
            score -= DISAPPEARPOINT * 9;

        setScoreTXT();
    }

    public void subScore()
    {
        score -= pointSub;
        setScoreTXT();
    }

    private void setScoreTXT() //텍스트 표기, 점수 검사
    {
        scoreTXT.text = score.ToString();

        //점수 높으면 클리어
        if (score >= 100)
        {
            clearStage();
        }

        //점수 낮으면 실패
        if (score <= 0)
        {
            loseStage();
        }
    }

    private void clearStage()
    {
        StageManager.updateClear(stage);
        TheEnd("성공!");
    }

    private void loseStage()
    {
        if (stage == 5)
            StageManager.updateClear(stage);

        TheEnd("실패!");
    }

    private void TheEnd(string endingMent) //팝업에는 확인 버튼 하나가 있고, 확인 버튼을 누르면 스테이지 선택 화면으로 이동.
    {
        SpawnManager.SetActive(false);
        pop.SetActive(true);
        endingTXT.text = endingMent;
    }
}
