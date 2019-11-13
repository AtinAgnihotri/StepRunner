using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private Animator myAnim;
    private BoxCollider2D myBC;
    private Rigidbody2D myRG;

    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
        //scoreCount = 0;
        //lifeCount = 1;
        //coinCount = 0;
        myAnim = GetComponent<Animator>();
        myBC = GetComponent<BoxCollider2D>();
        myRG = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    void UpdateUI()
    {
        GameplayController.instance.SetScore(scoreCount);
        GameplayController.instance.SetLifeScore(lifeCount);
        GameplayController.instance.SetCoinScore(coinCount);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
                //GameplayController.instance.SetScore(scoreCount);
                UpdateUI();
            }
            previousPosition = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        switch (target.tag)
        {
            case "Coin":
                coinCount++;
                scoreCount += 200;
                AudioSource.PlayClipAtPoint(coinClip, transform.position);
                //GameplayController.instance.SetScore(scoreCount);
                //GameplayController.instance.SetCoinScore(coinCount);
                UpdateUI();
                target.gameObject.SetActive(false);
                break;
            case "Life":
                lifeCount++;
                scoreCount += 300;
                AudioSource.PlayClipAtPoint(lifeClip, transform.position);
                //GameplayController.instance.SetScore(scoreCount);
                //GameplayController.instance.SetLifeScore(lifeCount);
                UpdateUI();
                target.gameObject.SetActive(false);
                break;
            case "Sandy":
                countScore = false;
                cameraScript.moveCamera = false;
                //transform.position = new Vector3(1000f, 1000f, 0f);
                myAnim.SetTrigger("Slide");
                myBC.enabled = false;
                myRG.gravityScale = 0f;
                lifeCount--;
                //GameplayController.instance.GameOverShowPanel(scoreCount, coinCount);
                GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
                break;
            case "Bounds":
                countScore = false;
                cameraScript.moveCamera = false;
                transform.position = new Vector3(1000f, 1000f, 0f);
                lifeCount--;
                //GameplayController.instance.GameOverShowPanel(scoreCount, coinCount);
                GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
                break;
        }
    }
}
