using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D _Rg;
    [SerializeField] float force;
    void Start()
    {
       
        Lacar();
    }


    public void Lacar()
    {
        _Rg.AddForce(-transform.right * force , ForceMode2D.Impulse);
    }
}
