using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDestroyer : MonoBehaviour
{
    GameObject checkTouch;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            destoryFire();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            Debug.Log("불이야 : " + collision.gameObject.tag);
            if(collision.gameObject.transform.position == checkTouch.transform.position)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public GameObject destoryFire()
    {
        // 1. player가 부딪힐 경우 (X축 방향 : 2칸, Y축 방향 : 1칸)
        // 2. 15초 마다 제시 되는 상황에서 '불'이 진화되는 상황 발생 시

        //캐릭터3번의 능력 : 터치해서 원하는 불 끌 수 있음

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.transform.gameObject.tag == "fire")
        {
            checkTouch = hit.transform.gameObject;
        }
        return checkTouch;
    }
}
