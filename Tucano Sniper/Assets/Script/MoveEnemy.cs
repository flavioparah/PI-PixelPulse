using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public int _Life;
    [SerializeField] float _Speed;
    [SerializeField] float _scaleX;
    [SerializeField] bool _dir;
    [SerializeField] ControlBullet _ControlBullet;
    public static MoveEnemy instance;


    Rigidbody2D _Rg;
    void Start()
    {
        instance = this;
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

        if (collision.gameObject.CompareTag("BalaTucano"))
        {

            _Life = _Life - 1;
        }
    }

    void TimerDir()
    {
        _dir = false;


    }

    public void lancar()
    {
        _ControlBullet.Lacar();

    }

}    
