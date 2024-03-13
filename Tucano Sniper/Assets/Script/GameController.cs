using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
public class GameController : MonoBehaviour
{
    [Header("Score")]
    public int _TotalScore;
    public TMP_Text _ScoreText;

    [Header("Life")]
    public int _Life;
    public int _TotalLife;
    public Image[] _Coracao;
    public Sprite _Cheio;
    public Sprite _Vazio;

    [Header("GameOver")]
    public GameObject _GameOver;


    public static GameController instance;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        HealtLogic();
    }

    public void UpdateScoreText()
    {
        _ScoreText.text = _TotalScore.ToString();
    }

    public void HealtLogic()
    {

        if(_Life > _TotalLife) 
        {
            _Life = _TotalLife;
        }

        for (int i = 0; i < _Coracao.Length; i++)
        {
            if (i < _Life) 
            {
                _Coracao[i].sprite = _Cheio;
            }
            else 
            {
                _Coracao[i].sprite = _Vazio;
            }

            if (i < _TotalLife)
            {
                _Coracao[i].enabled = true;
            }
            else 
            {
                _Coracao[i].enabled = false;
            }
           
        }
    }

    public void ShowGamerOver() 
    {
        _GameOver.SetActive(true);

        StartCoroutine(ShowGameOverAnimation());
    }

    IEnumerator ShowGameOverAnimation()
    {


        yield return new WaitForSeconds(0.5f);

        Time.timeScale = 0f;
    }



    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
        Time.timeScale = 1f;
    }


}
