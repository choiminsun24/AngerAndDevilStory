using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //�������� ���� �ٸ� ����
    public int pointAdd; //1�������� 10, 2�������� 5, 3�������� 5, 4�������� 3��
    public int pointSub; //1�������� 5, 2�������� 10, 3�������� 10, 4�������� 15��
    const int DISAPPEARPOINT = 2;
    public int stage; //�� ������������ ����. 1���������� 2, 2���������� 3, 3���������� 5, 4���������� 0.

    public GameObject SpawnManager;
    public GameObject pop;
    public TextMeshProUGUI endingTXT;
    public TextMeshProUGUI scoreTXT;

    //���� ����
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

        //���� ������ Ŭ����
        if (score >= 100)
        {
            clearStage();
        }

        setScoreTXT();
    }

    public void subScoreDisappear()
    {
        score -= DISAPPEARPOINT;
        setScoreTXT();
    }

    public void subScore()
    {
        score -= pointSub;

        //���� ������ ����
        if (score <= 0)
        {
            loseStage();
        }

        setScoreTXT();
    }

    private void setScoreTXT()
    {
        scoreTXT.text = score.ToString();
    }

    private void clearStage()
    {
        StageManager.updateClear(stage);
        TheEnd("����!");
    }

    private void loseStage()
    {
        if (stage == 5)
            StageManager.updateClear(stage);

        TheEnd("����!");
    }

    private void TheEnd(string endingMent) //�˾����� Ȯ�� ��ư �ϳ��� �ְ�, Ȯ�� ��ư�� ������ �������� ���� ȭ������ �̵�.
    {
        SpawnManager.SetActive(false);
        pop.SetActive(true);
        endingTXT.text = endingMent;
    }
}
