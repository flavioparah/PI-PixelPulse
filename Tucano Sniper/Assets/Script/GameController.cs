using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int _TotalScore;
    public Text _ScoreText;

    public static GameController instance;
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        _ScoreText.text = _TotalScore.ToString();
    }


}
