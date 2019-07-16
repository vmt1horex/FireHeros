using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharatorDetector : MonoBehaviour
{
    [SerializeField]
    private bool isFire;
    [SerializeField]
    private bool isRescue;

    public Fire cdr;
    public Rescue res;


    public bool hitFire
    {
        get { return isFire; }
    }

    public bool hitRescue
    {
        get { return isRescue; }
    }

    // Start is called before the first frame update
    void Start()
    {
        isFire = false;
        isRescue = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "fire")
        {
            isFire = true;
            cdr = collision.GetComponent<Fire>();
        }
        else if(collision.transform.tag == "rescue")
        {
            isRescue = true;
            res = collision.GetComponent<Rescue>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "fire")
        {
            isFire = false;
            cdr = null;
        }
        else if (collision.transform.tag == "rescue")
        {
            isRescue = false;
            res = null;
        }
    }
}
