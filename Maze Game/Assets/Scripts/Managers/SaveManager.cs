using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void Save(int level)
    {
        PlayerPrefs.SetInt("Level", level);
    }

    public void NextLvl() 
    {
        var temp = PlayerPrefs.GetInt("Level");
        temp ++;
        PlayerPrefs.SetInt("Level", temp);

    }
}
