using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstáculoMove : MonoBehaviour
{
    [SerializeField] float _SpeedObstaculo;
    public int _Score;
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
            Destroy(gameObject);

            GameController.instance._TotalScore += _Score;
            GameController.instance.UpdateScoreText();
        }
    }
}
