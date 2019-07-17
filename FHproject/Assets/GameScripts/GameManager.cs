using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //캐릭터 정보
    public Text ap;
    public int playAP;

    GameObject canv;

    Timer TM;

    FireGenerator FG;

    private void Awake()
    {
        playAP = 7;
        TM = GameObject.Find("Timer").GetComponent<Timer>();
        FG = GameObject.Find("FireGenerator").GetComponent<FireGenerator>();
        canv = GameObject.Find("Canvas");
    }

    private void Update()
    {
        //10초 마다 AP 회복
        if((int)TM.timer <= 0)
        {
            playAP = 7;
        }
        //AP 표시
        ap.text = string.Format("{0:f0}", "남은 AP : " + playAP);

        if(FG.fires.Length == 0)
        {
            SceneManager.LoadScene("StageClear");
        }
        else if(FG.fires.Length >= 60)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
