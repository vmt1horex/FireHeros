using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    //불 오브젝트 들의 HP Bar 등록
    [SerializeField]
    Image hpb;

    //불 프리펩을 가져옴
    public GameObject fr;

    //불의 하위에 있는 충돌체들을 가져옴
    public GameObject LeftCollis;
    public GameObject RightCollis;
    public GameObject UpCollis;
    public GameObject DownCollis;

    public FireDetector fd;

    //시간에 따라 불게이지 감소-> 불이 번지는 타이밍을 알려주는 UI
    void Update()
    {
        hpb.fillAmount += 0.1f * Time.deltaTime;
        if(hpb.fillAmount == 1f)
        {
            hpb.fillAmount = 0f;
        }
    }
    //불이 가지는 기능

    //진화된다
    public void Extinguish()
    {
        Destroy(gameObject);
    }

    //확산된다
    public void deffusionFire(int windDir)
    {
        // 1. 10초 마다 바람의 방향에 따라 각 '불'오브젝트 기준으로 1개 씩 생성
        // 2. 인화물질을 만나면 인화물질을 기준으로 동-서-남-북 사방으로 1개 씩 생성
        // 3. 15초 마다 상황이 제시되고, 상황에서 '불'의 확산 상황 발생 시
        // # 같은 위치에 중첩되지 않는다

        Vector3 nlocation;

        switch(windDir)
        {
            case 0://왼쪽 불 번짐
                fd = LeftCollis.GetComponent<FireDetector>();
                nlocation = transform.position;
                nlocation.x -= 0.7f;

                //불의 왼쪽에 불이 없고 맵을 벗어나지 않았다면 생성
                if(fd.hit==false && nlocation.x >= -2.3f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }

                break;

            case 1://우
                fd = RightCollis.GetComponent<FireDetector>();
                nlocation = transform.position;
                nlocation.x += 0.7f;

                //불의 오른쪽에 불이 업고 맵을 벗어나지 않았다면 생성
                if (fd.hit == false && nlocation.x <= 2.3f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }
                break;

            case 2://상
                fd = UpCollis.GetComponent<FireDetector>();
                nlocation = transform.position;
                nlocation.y += 0.7f;

                //불의 윗쪽에 불이 없고 맵을 벗어나지 않았다면 생성
                if (fd.hit == false && nlocation.y <= 4.2f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }
                break;

            case 3://하
                fd = DownCollis.GetComponent<FireDetector>();
                nlocation = transform.position;
                nlocation.y -= 0.7f;

                //불의 아랫쪽에 불이 없고 맵을 벗어나지 않았다면 생성
                if (fd.hit == false && nlocation.y >= -1.7f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }
                break;
        }

    }
}
