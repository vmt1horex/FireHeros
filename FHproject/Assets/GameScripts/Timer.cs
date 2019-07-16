using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text time;
    Button btn_exit;
    public float timer = 15.0f;

    void Update()
    {
        Times();
    }

    public void Times()
    {
        timer -= Time.deltaTime;
        time.text = string.Format("{0:f1}", timer -= Time.deltaTime);
        if (timer <= 0.0f)
        {
            timer = 15.0f;
        }
    }
}
