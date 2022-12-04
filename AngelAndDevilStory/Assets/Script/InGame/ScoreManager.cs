using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public int score = 0;

    // Start is called before the first frame update
    static public void addScore(int point)
    {
        score += point;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
