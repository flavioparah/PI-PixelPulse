using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material _Mat;
    float _Distance;

    [Range(0f, 0.5f)]
    public float _Speed = 0.2f;
    void Start()
    {
        _Mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _Distance += Time.deltaTime*_Speed;
        _Mat.SetTextureOffset("_MainTex", Vector2.right * _Distance);


    }
}
