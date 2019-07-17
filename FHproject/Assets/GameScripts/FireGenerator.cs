using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{

    public GameObject[] fires; //생성된 불을 보관하는 배열

    float span = 10.0f;
    float ranTime = 10.0f;


    int windDir;
    private void Awake()
    {
        this.fires = GameObject.FindGameObjectsWithTag("fire");
    }

    private void Update()
    {
        span -= Time.deltaTime;
        ranTime -= Time.deltaTime;

        if (ranTime <= 0.1f)
        {
            windDir = Random.Range(0, 4);
        }

        if (span <= 0.0f)
        {
            //생성된 불 검색
            this.fires = GameObject.FindGameObjectsWithTag("fire");

            this.span = 10.0f;

            createFires();

            //print(fires.Length); //불오브젝트가 잘 생성되는지 체크
        }
        
    }

    void createFires()
    {
        if (fires.Length < 70)
        {
            for (int i = 0; i < fires.Length; i++)
            {
                fires[i].GetComponent<Fire>().deffusionFire(windDir);
            }
        }
    }
}
