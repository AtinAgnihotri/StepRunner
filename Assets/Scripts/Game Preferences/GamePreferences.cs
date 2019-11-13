using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{
    /// <summary>
    /// 
    /// </summary>
    private static string easyDifficulty = "EasyDifficulty";
    private static string mediumDifficulty = "MediumDifficulty";
    private static string hardDifficulty = "HardDifficulty";

    private static string easyDifficultyHighScore = "EasyDifficultyHighScore";
    private static string mediumDifficultyHighScore = "MediumDifficultyHighScore";
    private static string hardDifficultyHighScore = "HardDifficultyHighScore";

    private static string easyDifficultyCoinHighScore = "EasyDifficultyCoinHighScore";
    private static string mediumDifficultyCoinHighScore = "MediumDifficultyCoinHighScore";
    private static string hardDifficultyCoinHighScore = "HardDifficultyCoinHighScore";
    
    private static string isMusicOn = "IsMusicOn";

    // 0 == False
    // 1 == False

    public static int EasyDifficulty
    {
        get 
        {
            return PlayerPrefs.GetInt(easyDifficulty);
        }
        set 
        {
            PlayerPrefs.SetInt(easyDifficulty, value);
        }
    }
    
    public static int MediumDifficulty
    {
        get 
        {
            return PlayerPrefs.GetInt(mediumDifficulty);
        }
        set 
        {
            PlayerPrefs.SetInt(mediumDifficulty, value);
        }
    }

    public static int HardDifficulty
    {
        get 
        {
            return PlayerPrefs.GetInt(hardDifficulty);
        }
        set 
        {
            PlayerPrefs.SetInt(hardDifficulty, value);
        }
    }

    public static int EasyDifficultyHighScore
    {
        get 
        {
            return PlayerPrefs.GetInt(easyDifficultyHighScore);
        }
        set 
        {
            PlayerPrefs.SetInt(easyDifficultyHighScore, value);
        }
    }

   public static int MediumDifficultyHighScore
    {
        get 
        {
            return PlayerPrefs.GetInt(mediumDifficultyHighScore);
        }
        set 
        {
            PlayerPrefs.SetInt(mediumDifficultyHighScore, value);
        }
    }

   public static int HardDifficultyHighScore
    {
        get 
        {
            return PlayerPrefs.GetInt(hardDifficultyHighScore);
        }
        set 
        {
            PlayerPrefs.SetInt(hardDifficultyHighScore, value);
        }
    }

   public static int EasyDifficultyCoinHighScore
    {
        get 
        {
            return PlayerPrefs.GetInt(easyDifficultyCoinHighScore);
        }
        set 
        {
            PlayerPrefs.SetInt(easyDifficultyCoinHighScore, value);
        }
    }

   public static int MediumDifficultyCoinHighScore
    {
        get 
        {
            return PlayerPrefs.GetInt(mediumDifficultyCoinHighScore);
        }
        set 
        {
            PlayerPrefs.SetInt(mediumDifficultyCoinHighScore, value);
        }
    }

   public static int HardDifficultyCoinHighScore
    {
        get 
        {
            return PlayerPrefs.GetInt(hardDifficultyCoinHighScore);
        }
        set 
        {
            PlayerPrefs.SetInt(hardDifficultyCoinHighScore, value);
        }
    }

   public static int IsMusicOn
    {
        get 
        {
            return PlayerPrefs.GetInt(isMusicOn);
        }
        set 
        {
            PlayerPrefs.SetInt(isMusicOn, value);
        }
    }

}
