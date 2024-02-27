using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D _Rg;
    [SerializeField] float force;
    [SerializeField] Transform _Pos;
    void Start()
    {
       
        //Lacar();
    }


    public void Lacar()
    {
        transform.position = _Pos.transform.position;
        _Rg.velocity = Vector2.zero;
        _Rg.AddForce(-transform.right * force , ForceMode2D.Impulse);
    }
}
