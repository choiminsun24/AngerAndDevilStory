using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private static int clearStage = 1; //현재까지 스테이지 클리어 정보.

    public static void updateClear(int clear)
    {
        StageManager.clearStage *= clear;
    }
}
