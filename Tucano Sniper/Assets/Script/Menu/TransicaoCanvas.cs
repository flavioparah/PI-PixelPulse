using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicaoCanvas : MonoBehaviour
{
    public GameObject _menuPrincipal;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AcionarTransicao()
    {
        
        _animator.SetTrigger("TransicaoCanvas");

       
        _menuPrincipal.SetActive(true);
    }
}
