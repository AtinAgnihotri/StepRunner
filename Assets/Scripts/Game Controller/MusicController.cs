using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private AudioSource audSrc;
    void Awake()
    {
        MakeSingleton();
        audSrc = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    
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

    public void PlayBGMusic(bool play)
    {
        if (play)
        {
            if (!audSrc.isPlaying)
            {
                audSrc.Play();
            }
        }
        else
        {
            if (audSrc.isPlaying)
            {
                audSrc.Stop();
            }
        }
        
    }
}
