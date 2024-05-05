using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] Image _barraDeVidaImage;

    public void AlteraBarraDeVida(int vidaAtual) 
    {
        float _fillAmount = vidaAtual / 100f;

        _barraDeVidaImage.fillAmount = _fillAmount;

    }
}
