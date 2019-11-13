using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private float transitionSpeed = 500f, initialTransitionSpeed = 500f;
    [SerializeField]
    private float transitionAccelaration = 100f;
    [SerializeField]
    private float maxTransitionSpeed = 7500f;
    
    private bool inMainMenu, inCredits, inOptionMenu, moveSlider, backFromOptions;
    [SerializeField]
    private GameObject mainMenu, optionsMenu, credits, canvasSlider;

    void Awake()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        optionsMenu = GameObject.FindGameObjectWithTag("Options");
        credits = GameObject.FindGameObjectWithTag("Credits");
        canvasSlider = GameObject.FindGameObjectWithTag("CanvasSlider");
        inMainMenu = true;
        inCredits = false;
        inOptionMenu = false;
        SetCanvasSliderCurrent();
        //Debug.Log("XPos is " + canvasSlider.transform.localPosition.x);
    }

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        GameManager.instance.gameRestartedAfterPlayerDied = false;
        //SceneManager.LoadScene("Level0");
        SceneFader.instance.LoadLevel("Level0");
    }

    public void ToggleSound()
    {

    }
    void SetDifficulty()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HighScore()
    {
        //SceneManager.LoadScene("HighScore");
        SceneFader.instance.LoadLevel("HighScore");
    }

    public void Credits()
    {
        credits.SetActive(true);
        inMainMenu = false;
        inCredits = true;
        moveSlider = true;
        transitionSpeed = initialTransitionSpeed;
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        inMainMenu = false;
        inOptionMenu = true;
        moveSlider = true;
        transitionSpeed = initialTransitionSpeed;
    }

    public void OptionsBackToMenu()
    {
        mainMenu.SetActive(true);
        inMainMenu = true;
        inOptionMenu = false;
        moveSlider = true;
        backFromOptions = true;
        transitionSpeed = initialTransitionSpeed;
    }

    public void CreditsBackToMenu()
    {
        mainMenu.SetActive(true);
        inMainMenu = true;
        inCredits = false;
        moveSlider = true;
        backFromOptions = false;
        transitionSpeed = initialTransitionSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetCanvasSliderCurrent()
    {
        //mainMenu.SetActive(inMainMenu);
        optionsMenu.SetActive(inOptionMenu);
        credits.SetActive(inCredits);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSlider)
        {
            Vector3 temp = canvasSlider.transform.localPosition;

            if (transitionSpeed < maxTransitionSpeed)
            {
                transitionSpeed += transitionAccelaration;
            }

            if (inMainMenu)
            {
                if (backFromOptions)
                {
                    if (temp.x >= 0f)
                    {
                        temp.x = 0f;
                        moveSlider = false;
                        SetCanvasSliderCurrent();
                    }
                    else
                    {
                        temp.x += transitionSpeed * Time.deltaTime;
                    }
                } else
                {
                    if (temp.x <= 0f)
                    {
                        temp.x = 0f;
                        moveSlider = false;
                        SetCanvasSliderCurrent();
                    }
                    else
                    {
                        temp.x -= transitionSpeed * Time.deltaTime;
                    }
                }

            } else if (inCredits) 
            {
                if (temp.x >= 2500f)
                {
                    //Debug.Log("Enters In Credits Crossing");
                    SetCanvasSliderCurrent();
                    temp.x = 2500f;
                    moveSlider = false;
                } else 
                {
                    temp.x += transitionSpeed * Time.deltaTime;
                }
            } else if (inOptionMenu) 
            {
                //Debug.Log("Options Transition");
                if (temp.x <= -2500f)
                {
                    //Debug.Log("Enters In Options Crossing");
                    temp.x = -2500f;
                    SetCanvasSliderCurrent();
                    moveSlider = false;
                }
                else
                {
                    temp.x -= transitionSpeed * Time.deltaTime;
                }
            }

            canvasSlider.transform.localPosition = temp;
            //Debug.Log("xpos is " + canvasSlider.transform.localPosition.x);
        }
    }
}
