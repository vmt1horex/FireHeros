using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player3Controller : MonoBehaviour
{
    public Text ap;

    GameObject player; //player 오브젝트
    GameObject touchFire;
    GameManager GM;

    Vector3 moving = new Vector3(0, 0, 0);

    void Start()
    {
        player = this.gameObject;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    float timer = 15.0f;

    //AP회복, 타이머
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            timer = 15.0f;
        }

    }


    //터치 된 불 끄기 : 타겟을 움직인 후 1초 내에 터치해야 꺼짐
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            touchFire = hit.transform.gameObject;



            if (collision.gameObject.transform.position == touchFire.gameObject.transform.position && GM.playAP > 4)
            {
                Destroy(collision.gameObject);
                GM.playAP = GM.playAP - 3;
                gameObject.transform.position = new Vector3(0, -2.2f, 0);
            }
        }
    }

    //public GameObject desTouch()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
    //    touchFire = hit.transform.gameObject;
    //
    //    return touchFire;
    //}

    // +Y 이동
    public void moveUp()
    {
        //좌표값 오류로 초기화 시켜줘야함
        moving = player.transform.position;

        if (moving.y <= 3.4f)
        {
            player.transform.Translate(0, 0.7f, 0);
        }
    }

    // -Y 이동
    public void moveDown()
    {
        //좌표값 오류로 초기화 시켜줘야함
        moving = player.transform.position;
        if (moving.y > -1.4f)
            {
                player.transform.Translate(0, -0.7f, 0);
            }
    }

    // -X 이동
    public void moveLeft()
    {
        moving = player.transform.position;

        if (moving.x >= -2.0f)
        {
            player.transform.Translate(-0.7f, 0, 0);
        }
    }


    // +X 이동
    public void moveRight()
    {
        moving = player.transform.position;

        if (moving.x <= 2.0f)
        {
            player.transform.Translate(0.7f, 0, 0);
        }
    }
}