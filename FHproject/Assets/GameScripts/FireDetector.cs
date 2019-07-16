using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetector : MonoBehaviour
{
    [SerializeField]
    private bool isHit;

    public Fire fr;

    public bool hit
    {
        get { return isHit; }
    }

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;       
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "fire")
        {
            isHit = true;
            fr = collision.GetComponent<Fire>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag=="fire")
        {
            Debug.Log(collision.tag);
            isHit = false;
            fr = null;
        }
    }
}
