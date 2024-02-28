using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeguirBotao : MonoBehaviour
{
    public Button[] botoes;
    public GameObject objetoSeguir;

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

                objetoSeguir.transform.position = new Vector3(objetoSeguir.transform.position.x, botao.transform.position.y - 0.19f);
                break;
            }
        }
    }

    public void botaoEntrou(Button botao)
    {
        objetoSeguir.transform.position = new Vector3(objetoSeguir.transform.position.x, botao.transform.position.y - 0.19f);
    }
}
