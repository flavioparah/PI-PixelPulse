using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeguirBotao : MonoBehaviour
{
    public Button[] botoes; 
    public GameObject objetoSeguir; 

    void Update()
    {
       
        foreach (Button botao in botoes)
        {
            if (botao.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            {
              
                objetoSeguir.transform.position = new Vector3 (objetoSeguir.transform.position.x, botao.transform.position.y - 0.19f);
                break;
            }
        }
    }
}
