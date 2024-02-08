using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [Header("Ground configuration")]
    public float _GroundInstan;
    public float _GroundSize;
    public float _GroundSpeed;
    
    public GameObject _GroundPrefab;
   

    void Start()
    {
        
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
}
