using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helice : MonoBehaviour
{
    public float velocidadeRotacao = 1000f; 

    void Update()
    {
       
        transform.Rotate(Vector3.up, velocidadeRotacao * Time.deltaTime);
    }
}
