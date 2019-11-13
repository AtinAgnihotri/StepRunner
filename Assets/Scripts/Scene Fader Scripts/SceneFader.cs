using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private Animator fadeAnim;                         

    public static SceneFader instance;
    void Awake()
    {
        MakeSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.5f));
        //fadeAnim.enabled = true;
        fadeAnim.Play("FadeOut");
        Debug.Log("Reach Here Why No FadeOut");
        fadePanel.SetActive(false);

    }

}
