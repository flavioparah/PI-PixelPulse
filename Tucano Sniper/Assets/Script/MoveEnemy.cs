using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class MoveEnemy : MonoBehaviour
{
    public int _Life;

    [SerializeField] float _Speed;
    [SerializeField] float _scaleX;
    [SerializeField] bool _dir;
    [SerializeField] ControlBullet _ControlBullet;
    public static MoveEnemy instance;

    [SerializeField] GameObject _Fumaca;

    [SerializeField] Animator _anim;

    [SerializeField] healthBar _healthBar;

    Rigidbody2D _Rg;

    string sceneName;

    public GameObject _placaExit;
    public GameObject _paredeRight;

    void Start()
    {
       
        instance = this;
 
        _Rg = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _healthBar.AlteraBarraDeVida(_Life);

        sceneName = SceneManager.GetActiveScene().name;
    }


    void Update()
    {
        _Rg.velocity = new Vector2(_Speed, _Rg.velocity.y);

        Dead();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco") && _dir == false)
        {
            _Speed = _Speed * -1;

            _dir = true;

            Invoke("TimerDir", 0.5f);
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

    public void Dead()
    {
        if (_Life <= 0) 
        {
            //_isBossScene = true;
            //TelaScore();
        
            timeDead();
            
        }
        
    }

    void timeDead()
    {

        Transform posEnemy = gameObject.transform;

        ControlBullet.instance.effectEnemy(posEnemy);

        Destroy(gameObject);

        _placaExit.SetActive(true);
        _paredeRight.SetActive(false);

    }

    void TelaScore()
    {
        Debug.Log('2');
        if (sceneName == "Boss")
        {
            Debug.Log('3');
            SceneManager.LoadScene("Score-screen");
        }
    }

}    
