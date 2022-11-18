using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnNeeds : MonoBehaviour
{
    public Transform[] spwnPoint; //������ ��ġ �迭
    public GameObject[] needs; //���� ������Ʈ �迭

    public int count = 0;
    public GameObject cvs;

    private float time, spwnTime;

    // Start is called before the first frame update
    void Start()
    {
        spwnTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (count != 0)
        {
            if (spwnTime < time)
            {
                Vector3 randomPoint  = spwnPoint[Random.Range(0, spwnPoint.Length)].position;
                GameObject randomNeed = needs[Random.Range(0, needs.Length)];

                Instantiate(randomNeed, randomPoint, Quaternion.identity, cvs.transform); //ĵ���� ������Ʈ ������ ����

                count--;
                time = 0;

                Debug.Log("�Լ� ����");
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }
}
