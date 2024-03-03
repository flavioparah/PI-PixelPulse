using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite disabledButtonSprite;

    [SerializeField] List<Transform> _itens;

    private void Start()
    {

        for (int i = 0; i < _itens.Count; i++)
        {
            _itens[i].localScale = Vector3.zero;
        }

        StartCoroutine(TimeItens());
    }
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < buttons.Length;  i++)
        {
            buttons[i].interactable = false;

            if (i > 1)
            {
                Image buttonImage = buttons[i].GetComponent<Image>();
                buttonImage.sprite = disabledButtonSprite;

            }

            ColorBlock colors = buttons[i].colors;
            colors.colorMultiplier = 5f;

            buttons[i].colors = colors;

        }

        for (int i = 0;i < unlockedLevel; i++) 
        {
            buttons[i].interactable = true;

            ColorBlock colors = buttons[i].colors;
            colors.colorMultiplier = 1f;

            buttons[i].colors = colors;
        }
    }
    public void openLevel(string levelId)
    {
        SceneManager.LoadScene(levelId);

    }

    IEnumerator TimeItens()
    {
        for (int i = 0;i < _itens.Count;i++)
        {
            yield return new WaitForSeconds(.09f);

            _itens[i].DOScale(0.7f, 0.25F);

            yield return new WaitForSeconds(.09f);

            _itens[i].DOScale(0.3642643f, 0.25F);

        }
    }
}
