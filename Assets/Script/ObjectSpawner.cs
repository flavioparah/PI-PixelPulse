using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private float _Speed = 5f;

    [SerializeField] private float _ObjectDistance = -40f;

    private bool CanSpawnGround = true;

    private Rigidbody2D _rb;
    void Start()
    {

      _rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {

        transform.position += -transform.forward * _Speed * Time.deltaTime;

        if (transform.position.x <= _ObjectDistance) { }
    }   
}


