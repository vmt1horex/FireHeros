using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int char_ID;
    public string charName;
    public int charHP;
    public int max_AP;

    public void CreateCharater()
    {

    }

    public void characterSelect(int characterID)
    {
        char_ID = characterID;
    }
}
