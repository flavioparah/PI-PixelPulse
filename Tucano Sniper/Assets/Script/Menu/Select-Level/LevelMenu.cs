using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite disabledButtonSprite;

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
}
