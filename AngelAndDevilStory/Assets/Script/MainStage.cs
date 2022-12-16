using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStage : MonoBehaviour
{
    public GameObject s2, s3, s4;

    public void Start()
    {
        int c = StageManager.getClearStage();

        if (c % 2 == 0)
            s2.SetActive(false);
        if(c % 3 == 0)
            s3.SetActive(false);
        if( c % 5 == 0)
            s4.SetActive(false);
    }
}