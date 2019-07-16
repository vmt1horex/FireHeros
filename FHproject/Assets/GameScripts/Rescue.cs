using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "fire")
        {
            Destroy(gameObject);
        }
        else if(collision.tag == "Player")
        {
            print("구조 됨");
        }
    }
}
