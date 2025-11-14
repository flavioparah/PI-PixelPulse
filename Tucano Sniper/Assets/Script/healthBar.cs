using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] Image _barraDeVidaImage;
    [SerializeField] int _vidaImagem;

    public void AlteraBarraDeVida(int vidaAtual)
    {
        if (_barraDeVidaImage == null) return;  

        float _fillAmount = (float)vidaAtual / _vidaImagem;
        _barraDeVidaImage.fillAmount = _fillAmount;
    }
}
