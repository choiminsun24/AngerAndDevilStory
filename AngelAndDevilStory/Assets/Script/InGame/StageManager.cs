using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private static int clearStage = 1; //������� �������� Ŭ���� ����.

    public static void updateClear(int clear)
    {
        StageManager.clearStage *= clear;
    }
}
