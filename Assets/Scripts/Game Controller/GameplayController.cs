using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayController : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static GameplayController instance;
    [SerializeField]
    private TMP_Text scoreText, lifeText, coinText;
    [SerializeField]
    private TMP_Text gameOverScoreText, gameOverCoinText;
    [SerializeField]
    private GameObject pausePanel, gameOverPanel;
    [SerializeField]
    private GameObject readyButton, pauseButton, coinUI, lifeUI, scoreUI;
    [SerializeField]
    private AudioClip deathClip, gameOverClip;
    //[SerializeField]
    //private TextMeshPro coinText;

    void Awake()
    {
        MakeInstance();    
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        coinUI.SetActive(false);
        lifeUI.SetActive(false);
        scoreUI.SetActive(false);
        scoreText.gameObject.SetActive(false);
        lifeText.gameObject.SetActive(false);
        coinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = "x " + score;
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x " + coinScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x " + lifeScore;
    }

    public void GamePause()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameToMainMenu()
    {
        Time.timeScale = 1f;
        //pausePanel.SetActive(false);
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
    }

    public void GameResume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GameOverShowPanel(int goScore, int goCoin)
    {
        pauseButton.SetActive(false);
        coinUI.SetActive(false);
        lifeUI.SetActive(false);
        scoreUI.SetActive(false);
        scoreText.gameObject.SetActive(false);
        lifeText.gameObject.SetActive(false);
        coinText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        //gameOverScoreText.text = "x " + goScore.ToString();
        gameOverScoreText.text = goScore.ToString();
        //gameOverCoinText.text = "x " + goCoin.ToString();
        gameOverCoinText.text = goCoin.ToString();
        //StartCoroutine("GameOverLoadMainMenu");
        AudioSource.PlayClipAtPoint(gameOverClip, Camera.main.transform.position);
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(4f);
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
    }

    public void LetsBegin()
    {
        readyButton.SetActive(false);
        pauseButton.SetActive(true);
        coinUI.SetActive(true);
        lifeUI.SetActive(true);
        scoreUI.SetActive(true);
        scoreText.gameObject.SetActive(true);
        lifeText.gameObject.SetActive(true);
        coinText.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void PlayerDiedRestartGame()
    {
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position);
        StartCoroutine("PlayerDiedRestart");
    }
    //public void GameOverLoadMainMenu()
    //{
    //    StartCoroutine("PlayerDiedRestart");
    //}

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene("Level0");
        SceneFader.instance.LoadLevel("Level0");
    }

    //IEnumerator GameOverLoadMenu()
    //{
    //    yield return new WaitForSeconds(4f);
    //    SceneManager.LoadScene("MainMenu");
    //}


}
