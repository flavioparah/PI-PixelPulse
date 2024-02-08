using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class GroundController : MonoBehaviour
{
    [Header("Ground configuration")]
    public float _GroundInstan;
    public float _GroundSize;
    public float _GroundSpeed;

    public bool _ChaoInstanciado;
    public GameObject _ChaoPrefab;
    Ground _ground;
   
     
    void Start()
    {
        _ground = FindAnyObjectByType(typeof(Ground)) as Ground;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MoverChao();
    }

    void Update()
    {
        MoverChao();
    }

    void MoverChao()
    {
        transform.Translate(Vector2.left * _GroundSpeed * Time.deltaTime);
    }

    void ChaoInstanciar()
    {
        if (!_ChaoInstanciado)
        {
           if (transform.position.x <= 0) 
           {
                _ChaoInstanciado = true;
                GameObject ObjetoTemporarioChao
                    
           }
        }
    }
}
