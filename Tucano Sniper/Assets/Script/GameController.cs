using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

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

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        HealtLogic();

        if (_Life <= 0)
        {
            ShowGamerOver();
        }
    }

    public void UpdateScoreText()
    {
        _ScoreText.text = _TotalScore.ToString();
    }

    // Atualiza os corações
    public void HealtLogic()
    {
        if (_Life > _TotalLife)
            _Life = _TotalLife;

        for (int i = 0; i < _Coracao.Length; i++)
        {
            if (i < _Life)
                _Coracao[i].sprite = _Cheio;
            else
                _Coracao[i].sprite = _Vazio;

            _Coracao[i].enabled = (i < _TotalLife);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(lvlName);
    }
}
