using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static int clearStage = 1; //������� �������� Ŭ���� ����.

    public static int getClearStage()
    {
        return clearStage;
    }
    public static void updateClear(int clear)
    {
        StageManager.clearStage *= clear;
    }
}
