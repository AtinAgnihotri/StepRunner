using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text easyText, mediumText, hardText;
    [SerializeField]
    private Toggle musicToggle;
    private bool isFirstTime;

    // Start is called before the first frame update
    void Start()
    {
        SetDifficulty();
        SetToggleMusic();
    }

    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                //easyText.fontStyle = TMPro.FontStyles.Italic;
                easyText.fontStyle = FontStyles.Bold | FontStyles.Italic;
                mediumText.fontStyle = FontStyles.Normal;
                hardText.fontStyle = FontStyles.Normal;
                break;
            case "Medium":
                easyText.fontStyle = FontStyles.Normal;
                //mediumText.fontStyle = TMPro.FontStyles.Italic;
                mediumText.fontStyle = FontStyles.Bold | FontStyles.Italic;
                hardText.fontStyle = FontStyles.Normal;
                break;
            case "Hard":
                easyText.fontStyle = FontStyles.Normal;
                mediumText.fontStyle = FontStyles.Normal;
                //hardText.fontStyle = TMPro.FontStyles.Italic;
                hardText.fontStyle = FontStyles.Bold | FontStyles.Italic;
                break;

        }
    }

    void SetDifficulty()
    {
        if (GamePreferences.EasyDifficulty == 1)
        {
            SetInitialDifficulty("Easy");
        }
        else if (GamePreferences.MediumDifficulty == 1)
        {
            SetInitialDifficulty("Medium");
        }
        else if (GamePreferences.HardDifficulty == 1)
        {
            SetInitialDifficulty("Hard");
        }
    }

    public void SetEasyDifficulty()
    {
        GamePreferences.EasyDifficulty = 1;
        GamePreferences.MediumDifficulty = 0;
        GamePreferences.HardDifficulty = 0;
        SetDifficulty();
    }

    public void SetMediumDifficulty()
    {
        GamePreferences.EasyDifficulty = 0;
        GamePreferences.MediumDifficulty = 1;
        GamePreferences.HardDifficulty = 0;
        SetDifficulty();
    }

    public void SetHardDifficulty()
    {
        GamePreferences.EasyDifficulty = 0;
        GamePreferences.MediumDifficulty = 0;
        GamePreferences.HardDifficulty = 1;
        SetDifficulty();
    }

    public void ToggleMusic()
    {
        if (isFirstTime) {
            isFirstTime = !isFirstTime;
            //Debug.Log("First Time Condition Entered, Music State: " + GamePreferences.IsMusicOn);
        }
        else
        {
            int i = GamePreferences.IsMusicOn;
            int finalI;
            if (i == 0)
            {
                GamePreferences.IsMusicOn = 1;
                finalI = 1;
                
            }
            else
            {
                GamePreferences.IsMusicOn = 0;
                MusicController.instance.PlayBGMusic(false);
                finalI = 0;
            }
            //Debug.Log("Initial Music State " + i);
            //Debug.Log("Final Music State " + finalI);
        }
        SetBGMusicState();
    }
    
    void SetBGMusicState()
    {
        if (GamePreferences.IsMusicOn == 1)
        {
            MusicController.instance.PlayBGMusic(true);
        }
        else
        {
            MusicController.instance.PlayBGMusic(false);
        }
    }

    public void SetToggleMusic()
    {
        
        int i = GamePreferences.IsMusicOn;
        //Debug.Log("Start Music State " + i);
        if (i == 0)
        {
            isFirstTime = true;
            musicToggle.isOn = false;
            MusicController.instance.PlayBGMusic(false);
            //Debug.Log("Entered Turned Off Cond");

        }
        else
        {
            isFirstTime = false;
            musicToggle.isOn = true;
            MusicController.instance.PlayBGMusic(true);
            //Debug.Log("Entered Turned Om Cond");
        }

        SetBGMusicState();
    }
}
