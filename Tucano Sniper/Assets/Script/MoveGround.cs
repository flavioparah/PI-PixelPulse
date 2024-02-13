using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{

    public float _GroundSpeed;
 
    void FixedUpdate()
    {
        MoverChao();
    }
    void MoverChao()
    {
        transform.Translate(Vector2.left * _GroundSpeed * Time.deltaTime);
    }
}
