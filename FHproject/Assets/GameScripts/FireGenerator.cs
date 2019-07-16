using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject[] fires; //생성된 불을 보관하는 배열

    float span = 5.0f;

    private void Update()
    {
        span -= Time.deltaTime;
        if (this.span <= 0)
        {
            //생성된 불 검색
            this.fires = GameObject.FindGameObjectsWithTag("fire");

            this.span = 5;
            int windDir = Random.Range(0, 4);


            if (fires.Length < 70)
            {
                for (int i = 0; i < fires.Length; i++)
                {
                    fires[i].GetComponent<Fire>().deffusionFire(windDir);
                }
            }
            //print(fires.Length); //불오브젝트가 잘 생성되는지 체크
        }
    }
}
