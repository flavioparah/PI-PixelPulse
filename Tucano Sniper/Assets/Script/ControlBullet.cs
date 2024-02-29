using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D _Rg;
    [SerializeField] float force;
    [SerializeField] Transform _Pos;
    private bool _colisaoDetectada = false;
    GameController _gameController;
    void Start()
    {
        _gameController = (GameController)FindAnyObjectByType(typeof(GameController));
        //Lacar();
    }


    public void Lacar()
    {
        transform.position = _Pos.transform.position;
        _Rg.velocity = Vector2.zero;
        _Rg.AddForce(-transform.right * force, ForceMode2D.Impulse);
    }

    public void LacarTucano()
    {
        transform.position = _Pos.transform.position;
        transform.rotation = _Pos.transform.rotation;
        _Rg.velocity = Vector2.zero;
        _Rg.AddForce(transform.right * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_colisaoDetectada && collision.gameObject.CompareTag("Player"))
        {
            _gameController._Life -= 1;
            _colisaoDetectada = true;
       
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _colisaoDetectada = false;
        }

       
    }

}