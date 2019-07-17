using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject fr;

    //캐릭터 정보
    public Text ap;

    FireGenerator FG;

    public int playAP;

    private void Start()
    {
        playAP = 10;
    }

    private void Update()
    {

    }
}
