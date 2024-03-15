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
    [SerializeField] Transform _transform;
    [SerializeField] Transform _transformGato;

    [SerializeField] GameObject _Fumaca;

    [SerializeField] Animator _anim;

    [SerializeField] healthBar _healthBar;


    Rigidbody2D _Rg;
    void Start()
    {
       
        instance = this;
        _Rg = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _healthBar.AlteraBarraDeVida(_Life);
    }


    void Update()
    {
        _Rg.velocity = new Vector2(_Speed, _Rg.velocity.y);
        Dead();

        //_transform.position = new Vector2(_transformGato.position.x, _transformGato.position.y);

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

            _anim.SetBool("Hit", true);

            Destroy(collision.gameObject);

            _healthBar.AlteraBarraDeVida(_Life);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaTucano"))
        {

            StartCoroutine(timeAnimation());
        }
    }

    IEnumerator timeAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        _anim.SetBool("Hit", false);
    }

    void TimerDir()
    {
        _dir = false;


    }

    public void lancar()
    {
        _ControlBullet.Lacar();

    }

    public void Dead()
    {
        if (_Life <= 0) 
        {
            StartCoroutine(timeDead());
        }
        
    }

    IEnumerator timeDead()
    {
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
        _Fumaca.SetActive(true);
    }

}    
