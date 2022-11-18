using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnNeeds : MonoBehaviour
{
    public Transform[] spwnPoint; //생성될 위치 배열
    public GameObject[] needs; //만들 오브젝트 배열

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

                Instantiate(randomNeed, randomPoint, Quaternion.identity, cvs.transform); //캔버스 오브젝트 하위에 생성

                count--;
                time = 0;

                Debug.Log("함수 진입");
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }
}
