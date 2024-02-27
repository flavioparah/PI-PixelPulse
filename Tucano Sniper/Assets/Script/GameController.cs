using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int _TotalScore;
    public TMP_Text _ScoreText;

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
