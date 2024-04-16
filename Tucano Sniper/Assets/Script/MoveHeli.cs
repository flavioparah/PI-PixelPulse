using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeli : MonoBehaviour
{
    public int _Life;
    [SerializeField] float _Speed;
    [SerializeField] float _scaleX;
    [SerializeField] bool _dir;
    [SerializeField] ControlBullet _ControlBullet;


    [SerializeField] Animator _anim;


    Rigidbody2D _Rg;
    void Start()
    {


        _Rg = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        _Rg.velocity = new Vector2(_Speed, _Rg.velocity.y);
        Dead();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco") && _dir == false)
        {
            _Speed = _Speed * -1;
            _scaleX = _scaleX * -1;
            _dir = true;
            transform.localScale = new Vector2(_scaleX, 2);

            Invoke("TimerDir", 0.5f);
        }

        if (collision.gameObject.CompareTag("BlocoTiro"))
        {
            Debug.Log("Chamou?");
            _ControlBullet.Heli();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaTucano"))
        {

        }
    }

    void TimerDir()
    {
        _dir = false;


    }


    public void Dead()
    {
        if (_Life <= 0)
        {
            Destroy(gameObject);

        }

    }


}
