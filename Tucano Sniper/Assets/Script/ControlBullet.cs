using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ControlBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D _Rg;
    [SerializeField] float force;
    [SerializeField] Transform _pos;
 
    void Start()
    {
       
        //Lacar();
    }


    public void Lacar()
    {
        transform.position = _pos.position;
        _Rg.velocity = Vector2.zero;

        _Rg.AddForce(-transform.right * force , ForceMode2D.Impulse);
    }
}
