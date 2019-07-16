using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject fr;

    //캐릭터 정보
    public Text ap;
    public Text hp;

    FireGenerator FG;
    private void Awake()
    {
        //this.FG = GameObject.Find("FireGenerator").GetComponent<FireGenerator>();
    }

    private void Start()
    {
        //FG.fires[0] = Instantiate(fr, new Vector3(-0.7f, 0.6f, 0f), transform.rotation);
        //FG.fires[1] = Instantiate(fr, new Vector3(1.4f, 1.3f, 0f), transform.rotation);
        //FG.fires[2] = Instantiate(fr, new Vector3(-0.7f, -0.8f, 0f), transform.rotation);
        //FG.fires[3] = Instantiate(fr, new Vector3(-2.1f, 1.3f, 0f), transform.rotation);
    }

    private void Update()
    {

    }
}
