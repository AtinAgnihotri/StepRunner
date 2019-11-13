using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText, coinText, difficultyText;
    // Start is called before the first frame update
    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScoreTab(int score, int coinScore, string difficulty)
    {
        difficultyText.text = difficulty;
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

    void SetScoreBasedOnDifficulty()
    {
        if (GamePreferences.EasyDifficulty == 1)
        {
            SetScoreTab(GamePreferences.EasyDifficultyHighScore, GamePreferences.EasyDifficultyCoinHighScore, "EASY");
        }
        else if (GamePreferences.MediumDifficulty == 1)
        {
            SetScoreTab(GamePreferences.MediumDifficultyHighScore, GamePreferences.MediumDifficultyCoinHighScore, "MEDIUM");
        }
        else if (GamePreferences.HardDifficulty == 1)
        {
            SetScoreTab(GamePreferences.HardDifficultyHighScore, GamePreferences.HardDifficultyCoinHighScore, "HARD");
        }
    }

   public void BackToMenu()
    {
        /*SceneManager.LoadScene("MainMenu")*/
        SceneFader.instance.LoadLevel("MainMenu");
    }
}
