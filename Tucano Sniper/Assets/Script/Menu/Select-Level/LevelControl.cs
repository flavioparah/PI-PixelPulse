using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    [SerializeField] List<GameObject> _painels;

    [SerializeField] Button[] botoes;

    [SerializeField] Sprite _spriteSelecionada;
    [SerializeField] Sprite _spriteDesativada;

    [SerializeField] Image[] _img;
    
    void Start()
    {
        _painels[1].SetActive(true);

        selecionarBotao(28);

        _img[0].sprite = _spriteSelecionada;
    }

    private void Update()
    {
        foreach (Button botao in botoes)
        {
            EventTrigger trigger = botao.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = botao.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((data) => { botaoEntrou(botao); });
            trigger.triggers.Add(entryEnter);
        }

        }

    public void ativarPainel(int id)
    {
        if (id == 1) 
        {
            _painels[0].SetActive(true);
            _painels[1].SetActive(false);
            _painels[2].SetActive(false);

            selecionarBotao(8);


            _img[0].sprite = _spriteSelecionada;
            _img[1].sprite = _spriteDesativada;
            _img[2].sprite = _spriteDesativada;
        } 

        if (id == 2)
        {
            _painels[0].SetActive(false);
            _painels[1].SetActive(true);
            _painels[2].SetActive(false);

            selecionarBotao(18);

            _img[1].sprite = _spriteSelecionada;
            _img[0].sprite = _spriteDesativada;
            _img[2].sprite = _spriteDesativada;
        } 

        if (id == 3)
        {
            _painels[0].SetActive(false);
            _painels[1].SetActive(false);
            _painels[2].SetActive(true);

            selecionarBotao(27);

            _img[2].sprite = _spriteSelecionada;
            _img[0].sprite = _spriteDesativada;
            _img[1].sprite = _spriteDesativada;
        }
        
    }

    void botaoEntrou(Button botao)
    {

        if (botao.interactable != false)
        {
            botao.Select();
        }
        
    }

    void selecionarBotao(int id)
    {
        botoes[id].Select();
    }

}
