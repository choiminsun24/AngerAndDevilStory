using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool[] AandD; //[0]는 천사가 눌렸는지 여부, [1]은 악마가 눌렸는지 여부를 나타냄.
    public int helpness = 0;

    // Start is called before the first frame update
    void Start()
    {
        AandD = new bool[2];
        //천사 악마 bool 디폴트로 세팅
        AandD[0] = false;
        AandD[1] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int change_helpness() //새로운 helpness 값을 반환
    {
        if (AandD[0])
        {
            if (AandD[1])
                return 3; //천사가 true고 악마가 true
            else
                return 1; //천사가 true고 악마가 false
        }
        else
        {
            if (AandD[1])
                return 2; //천사가 false고 악마가 true
            else
                return 0; //천사가 false고 악마가 false
        }
    }

    public void set_help(int btn)
    {
        AandD[btn] = !AandD[btn];

        Debug.Log(AandD[btn]);

        helpness = change_helpness();
    }
}
