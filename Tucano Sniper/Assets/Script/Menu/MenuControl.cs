using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] Button[] botoes;
    public GameObject obj;

    private void Start()
    {
        chamarMenu();
    }

    void Update()
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

            if (botao.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, botao.transform.position.y - 0.13f);
            }

        }
    }

    void chamarMenu()
    {
        botoes[3].Select();
    }

    void botaoEntrou(Button botao) 
    {
        botao.Select();
    }
}
