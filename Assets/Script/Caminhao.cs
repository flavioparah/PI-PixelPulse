using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminhao : MonoBehaviour
{
    Rigidbody2D _Rig;
    float _velocidade;
    void Start()
    {
        _Rig =GetComponent<Rigidbody2D>();
        _velocidade = 1;
        _velocidade = _velocidade++;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        _Rig.velocity = new Vector2(_velocidade, _Rig.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _velocidade = 8;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _velocidade = 1;
    }
}
