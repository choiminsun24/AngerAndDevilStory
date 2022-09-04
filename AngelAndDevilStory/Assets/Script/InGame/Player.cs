using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool[] AandD; //[0]�� õ�簡 ���ȴ��� ����, [1]�� �Ǹ��� ���ȴ��� ���θ� ��Ÿ��.
    public int helpness = 0;

    // Start is called before the first frame update
    void Start()
    {
        AandD = new bool[2];
        //õ�� �Ǹ� bool ����Ʈ�� ����
        AandD[0] = false;
        AandD[1] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int change_helpness() //���ο� helpness ���� ��ȯ
    {
        if (AandD[0])
        {
            if (AandD[1])
                return 3; //õ�簡 true�� �Ǹ��� true
            else
                return 1; //õ�簡 true�� �Ǹ��� false
        }
        else
        {
            if (AandD[1])
                return 2; //õ�簡 false�� �Ǹ��� true
            else
                return 0; //õ�簡 false�� �Ǹ��� false
        }
    }

    public void set_help(int btn)
    {
        AandD[btn] = !AandD[btn];

        Debug.Log(AandD[btn]);

        helpness = change_helpness();
    }
}
