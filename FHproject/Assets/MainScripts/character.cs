﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public int currentSp;
    public int characterId;
    public int skill1;
    public int skill2;
    // Start is called before the first frame update
    public void Awake()
    {
        characterId = 1;
        if (PlayerPrefs.HasKey("currentSp") == false)
        {
            currentSp = 0;

        }
        else if (PlayerPrefs.HasKey("currentSp") == true)
        {
            currentSp = PlayerPrefs.GetInt("currentSp");
        }


    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(characterId);
    }


}
