using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public string[] scenesToPlayAudioIn;
    private static AudioManager instance;
    private static float musicPosition = 0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        GetComponent<AudioSource>().time = musicPosition;
       
        GetComponent<AudioSource>().Play();

    }

    void Update()
    {
       
        musicPosition = GetComponent<AudioSource>().time;

        string currentScene = SceneManager.GetActiveScene().name;
        bool playAudio = false;

        foreach (string sceneName in scenesToPlayAudioIn)
        {
            if (currentScene == sceneName)
            {
                playAudio = true;
                break;
            }
        }

        if (playAudio && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        else if (!playAudio && GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Pause();
        }
    }

}
