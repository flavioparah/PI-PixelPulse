using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstáculo_Control : MonoBehaviour
{
    [Header("Configuração Do Obstáculo")]
    [SerializeField] float _SpeedObstaculo;
    [SerializeField] float _ObstaculoTempo;
    [SerializeField] GameObject _ObstaculoPrefab;
   
    void Start()
    {
        
        StartCoroutine("SpawObstaculo");

    }

    IEnumerator SpawObstaculo()
    {

        yield return new WaitForSeconds(_ObstaculoTempo);

        GameObject ObjetoObstaculoTemp = Instantiate(_ObstaculoPrefab);
        StartCoroutine("SpawObstaculo");


    }
}
