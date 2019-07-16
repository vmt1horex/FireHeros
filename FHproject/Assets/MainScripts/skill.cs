using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    GameObject skill1SP;
    GameObject skill2SP;
    public GameObject Player;
    public int skillPoint;
    public int skill1PointSPText;
    public int skill2PointSPText;
    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.Find("Player");
        this.skill1SP = GameObject.Find("returnNeedSP1");
        this.skill2SP = GameObject.Find("returnNeedSP2");
     //   hpUp skill1 = new hpUp();
       // skill1.skillPoint = 5;
       // rangeUp skill2 = new rangeUp();
        //skill2.skillPoint = 8;
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
     
}

