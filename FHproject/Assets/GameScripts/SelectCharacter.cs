using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    //캐릭터마다 다른 버튼으로 컨트롤
    public GameObject btn_player1;
    public GameObject btn_player2;
    public GameObject btn_player3;

    public void Select_Player1()
    {
        btn_player1.gameObject.SetActive(true);
        btn_player2.gameObject.SetActive(false);
        btn_player3.gameObject.SetActive(false);
    }

    public void Select_Player2()
    {
        btn_player1.gameObject.SetActive(false);
        btn_player2.gameObject.SetActive(true);
        btn_player3.gameObject.SetActive(false);
    }

    public void Select_Player3()
    {
        btn_player1.gameObject.SetActive(false);
        btn_player2.gameObject.SetActive(false);
        btn_player3.gameObject.SetActive(true);
    }
}
