using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static GameManager instance;
    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;
    [HideInInspector]
    public int score, coinScore, lifeScore;
    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables(); 
    }

    void InitializeVariables()
    {
        if(!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.EasyDifficulty = 0;
            GamePreferences.MediumDifficulty = 1;
            GamePreferences.HardDifficulty = 0;

            GamePreferences.EasyDifficultyHighScore = 0;
            GamePreferences.MediumDifficultyHighScore = 0;
            GamePreferences.HardDifficultyHighScore = 0;

            GamePreferences.EasyDifficultyCoinHighScore = 0;
            GamePreferences.MediumDifficultyCoinHighScore = 0;
            GamePreferences.HardDifficultyCoinHighScore = 0;

            GamePreferences.IsMusicOn = 1;

            PlayerPrefs.SetInt("Game Initialized", 1);
            //Debug.Log("Created Prefs");
        }
        //else
        //{
        //    Debug.Log("Has Prefs");
        //}
    }

    // Update is called once per frame
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }           
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level0")
        {
            Debug.Log("Loaded Level0");
            if (gameRestartedAfterPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
                Debug.Log("GameRestarted\nScore: " + PlayerScore.scoreCount + ", Life: " + PlayerScore.lifeCount + ", Coin:" + PlayerScore.coinCount);
            }
            else if (gameStartedFromMainMenu)
            {
                

                //PlayerScore.scoreCount = score;
                PlayerScore.scoreCount = 0;
                //PlayerScore.coinCount = coinScore;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);
                Debug.Log("GameStarted\nScore: " + PlayerScore.scoreCount + ", Life: " + PlayerScore.lifeCount + ", Coin:" + PlayerScore.coinCount);
            }
        }
        //} else if (gameStartedFromMainMenu)
        //{

        //}
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore <= 0)
        {
            if(GamePreferences.EasyDifficulty == 1)
            {
                int highScore = GamePreferences.EasyDifficultyHighScore;
                int coinHighScore = GamePreferences.EasyDifficultyCoinHighScore;
                if (score > highScore)
                    GamePreferences.EasyDifficultyHighScore = score;
                if (coinScore > coinHighScore)
                    GamePreferences.EasyDifficultyCoinHighScore = coinScore;
            }
            if(GamePreferences.MediumDifficulty == 1)
            {
                int highScore = GamePreferences.MediumDifficultyHighScore;
                int coinHighScore = GamePreferences.MediumDifficultyCoinHighScore;
                if (score > highScore)
                    GamePreferences.MediumDifficultyHighScore = score;
                if (coinScore > coinHighScore)
                    GamePreferences.MediumDifficultyCoinHighScore = coinScore;
            }
            if(GamePreferences.HardDifficulty == 1)
            {
                int highScore = GamePreferences.HardDifficultyHighScore;
                int coinHighScore = GamePreferences.HardDifficultyCoinHighScore;
                if (score > highScore)
                    GamePreferences.HardDifficultyHighScore = score;
                if (coinScore > coinHighScore)
                    GamePreferences.HardDifficultyCoinHighScore = coinScore;
            }


            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;
            GameplayController.instance.GameOverShowPanel(score, coinScore);
            //GameplayController.instance.GameOverShowPanel();

        } else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;
            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;
            //GameplayController.instance.SetScore(score);
            //GameplayController.instance.SetCoinScore(coinScore);
            //GameplayController.instance.SetLifeScore(lifeScore);
            GameplayController.instance.PlayerDiedRestartGame();
        }
    }
}
