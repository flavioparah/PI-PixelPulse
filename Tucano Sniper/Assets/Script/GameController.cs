using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{

    public int _TotalScore;
    public TMP_Text _ScoreText;

    public int _Life;
    public int _TotalLife;
    public Image[] _Coracao;
    public Sprite _Cheio;
    public Sprite _Vazio;


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


}
