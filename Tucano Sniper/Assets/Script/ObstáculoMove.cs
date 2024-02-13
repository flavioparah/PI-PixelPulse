using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstáculoMove : MonoBehaviour
{
    [SerializeField] float _SpeedObstaculo;
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * _SpeedObstaculo * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Colidiu");
        }
    }
}
