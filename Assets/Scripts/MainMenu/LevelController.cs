using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelController : MonoBehaviour
{
    public static void WriteLevelData(int value, bool unlockNextLevel)
    {
        string levelData = PlayerPrefs.GetString("Levels/" + SceneManager.GetActiveScene().name, "");
        if (levelData.Equals(""))
        {
            PlayerPrefs.SetString("Levels/" + SceneManager.GetActiveScene().name, "true," + value);
        }
        else
        {
            if (value > Convert.ToInt16(levelData.Split(',')[1]))
            {
                PlayerPrefs.SetString("Levels/" + SceneManager.GetActiveScene().name, "true," + value);
            }
        }

        if (unlockNextLevel)
        {
            PlayerPrefs.SetString("Levels/" + BondsLibrary.GetNextLevelName(SceneManager.GetActiveScene().name), "true,0");
        }
    }
}
