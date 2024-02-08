using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{

    [SerializeField] private float _Speed = 5f;

    [SerializeField] private float _ObjectDistance = -40f;

    [SerializeField] private float _DespawnDistance = -110f;

    private bool CanSpawnGround = true;

    private Rigidbody _Rb;

    private void Start()
    {
       _Rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += -transform.forward * _Speed * Time.deltaTime;
        
        //if(transform.position.z <= _ObjectDistance && transform.tag == "Ground" && CanSpawnGround) 
        {
            //ObjectSpawner.instance.SpawnGround();
            //anSpawnGround = false;
        
        }
    }
}
