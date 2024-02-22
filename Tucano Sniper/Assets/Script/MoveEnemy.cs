using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] float _Speed;
    [SerializeField] float _scaleX;
    [SerializeField] bool _dir;
    [SerializeField] ControlBullet _bullet;

    Rigidbody2D _Rg;
    void Start()
    {
        _Rg = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        _Rg.velocity = new Vector2(_Speed, _Rg.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco") && _dir == false)
        {
            _Speed = _Speed * -1;
            //_scaleX = _scaleX * -2;
            _dir = true;
            //transform.localScale = new Vector2(_scaleX, 2);

            Invoke("TimerDir", 0.5f);
        }
    }

    void TimerDir()
    {
        _dir = false;


    }

    public void Atirar()
    {
        _bullet.Lacar();


    }

}
