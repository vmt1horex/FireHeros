using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour
{
    public CharatorDetector CD;
    public FireDetector FD;

    public GameObject P_LeftCollis;
    public GameObject P_RightCollis;
    public GameObject P_UpCollis;
    public GameObject P_DownCollis;

    public Text ap;
    public Text hp;

    GameObject player; //player 오브젝트

    Vector3 moving = new Vector3(0, 0, 0);

    int playerAP = 4;
    int playerHP = 3; 
    int rescueMax = 1; //구조 할 수 있는 최대 인원
    

    void Start()
    {
        player = this.gameObject;
    }

    float P1_timer = 7.5f;

    //AP회복 타이머
    void Update()
    {
        P1_timer -= Time.deltaTime;
        ap.text = string.Format("{0:f0}", "남은 AP : " + playerAP);
        hp.text = string.Format("{0:f0}", "HP : " + playerHP);
        if (playerHP == 0)
        {
            Destroy(gameObject);
            ap.text = "사망";
            hp.text = "";
        }
        else if (P1_timer < 0.0f)
        {
            {
                P1_timer = 7.5f;
                playerAP = 4;
            }
            //타이머 표시
            ap.text = string.Format("{0:f0}", "남은 AP : " + playerAP);

            //HP표시
            hp.text = string.Format("{0:f0}", "HP : " + playerHP);
        }

    }


    
    public void OnTriggerStay2D(Collider2D collision)
    {
        //불에 닿으면 HP - 1 and 캐릭터와 겹쳐진 불은 삭제
        if (collision.gameObject.tag == "fire")
        {
            --playerHP;
            Destroy(collision.gameObject);
        }
    }

    // +Y 이동
    public void moveUp()
    {
        CD = P_UpCollis.GetComponent<CharatorDetector>();
       
        //좌표값 오류로 초기화 시켜줘야함
        moving = player.transform.position;

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (playerAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            if (CD.hitFire == true)
            {
                player.transform.position = moving; //이동하지 않음
                Destroy(CD.cdr.gameObject); // 닿아 있는 불 제거
                playerAP--;
            }
            //닿아 있지 않다면 이동. AP -1
            else if (moving.y <= 3.4f && (moving.x >= -0.1 && moving.x <= 0.1))
            {
                player.transform.Translate(0, 0.7f, 0);
                playerAP--;
            }
        }
    }

    // -Y 이동
    public void moveDown()
    {
        CD = P_DownCollis.GetComponent<CharatorDetector>();

        //좌표값 오류로 초기화 시켜줘야함
        moving = player.transform.position;

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (playerAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            if (CD.hitFire == true)
            {
                player.transform.position = moving;
                Destroy(CD.cdr.gameObject);
                playerAP--;
            }
            //최대 움직일 수 있는 범위 설정, x좌표 값 오류로 범위 체크해야 함
            else if ((moving.x >= -0.1 && moving.x <= 0.1) && moving.y > -1.6f)
            {
                player.transform.Translate(0, -0.7f, 0);
                playerAP--;

                //구조자를 업은 상태이고 출구로 나오면 구조 성공
                if(player.transform.position.y == -2.2f && rescueMax == 0)
                {
                    rescueMax = 1;
                    Debug.Log("환자 구함");
                }
            }
        }
    }

    // -X 이동
    public void moveLeft()
    {
        moving = player.transform.position;
        CD = P_LeftCollis.GetComponent<CharatorDetector>();

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (playerAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            // 최대 움직일 수 있는 범위 설정
            if (moving.x < -2.3f || CD.hitFire == true) 
            {
                player.transform.position = moving;

                //캐릭터와 부딪힌 불 왼쪽에 불이 있는지 FireDetecter에서 참조한다
                if (CD.cdr.LeftCollis.GetComponent<FireDetector>().fr != null)
                {
                    //불 왼쪽에 불이 닿아 있다면 삭제
                    // X축은 2칸 씩 불을 끌 수 있다
                    Destroy(CD.cdr.LeftCollis.GetComponent<FireDetector>().fr.gameObject);
                }
                //캐릭터와 닿아 있는 불 삭제
                Destroy(CD.cdr.gameObject);
                playerAP--;
            }

            //구조자를 업는다
            else if (CD.hitRescue == true && rescueMax !=0)
            {
                player.transform.position = moving;
                Destroy(CD.res.gameObject);
                playerAP--;
                rescueMax--;
            }
            //한번에 구할 수 있는 한계치가 있다
            else if (CD.hitRescue == true && rescueMax == 0)
            {
                player.transform.position = moving;
                //최대 한명만 구조할 수 있습니다
                print("eekap");
            }

            //불에 닿아 있지 않다면 이동
            else if (moving.y > -2.0f && moving.y < 4.8f && moving.x > -2.1f)
            {
                player.transform.Translate(-0.7f, 0, 0);
                playerAP--;
            }
        }
        
    }

    // +X 이동
    public void moveRight()
    {
        
        moving = player.transform.position;

        CD = P_RightCollis.GetComponent<CharatorDetector>();

        // 이동 조건 : 계단에서만 이동 가능하고, 불이 있다면 이동하지 않음
        // AP(행동력)이 있을 때만 행동(불끄기, 이동)이 가능함

        // AP 체크
        if (playerAP == 0)
        {
            print("AP없음");
        }
        else
        {
            //CharaterDetecter에 불이 닿았는지 판별
            //닿아 있다면 이동하지 않고 불을 끄는 행동을 한다. AP -1
            // 최대 움직일 수 있는 범위 설정
            if (moving.x > 2.0f || CD.hitFire == true)
            {
                player.transform.position = moving;

                //캐릭터와 부딪힌 불 왼쪽에 불이 있는지 FireDetecter에서 참조한다
                if (CD.cdr.RightCollis.GetComponent<FireDetector>().fr != null)
                {
                    //불 오른쪽에 불이 닿아 있다면 삭제
                    // X축은 2칸 씩 불을 끌 수 있다
                    Destroy(CD.cdr.RightCollis.GetComponent<FireDetector>().fr.gameObject);
                }

                // 닿아 있는 불 삭제
                Destroy(CD.cdr.gameObject);
                playerAP--;
            }

            //구조자를 업는다
            else if (CD.hitRescue == true && rescueMax != 0)
            {
                player.transform.position = moving;
                Destroy(CD.res.gameObject);
                playerAP--;
                rescueMax--;
            }
            //구조할 수 있는 한계치가 있다
            else if (CD.hitRescue == true && rescueMax == 0)
            {
                player.transform.position = moving;
                //최대 한 명만 구조할 수 있습니다
                print("eekap");
            }

            // 닿아 있는 불이 없다면 이동
            else if (moving.y > -2.0f && moving.y < 4.8f && moving.x <= 2.1f)
            {
                player.transform.Translate(0.7f, 0, 0);
                playerAP--;
            }
        }
    }
}
