using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D _Rg;
    [SerializeField] float force;
    [SerializeField] Transform _Pos;
    GameController _gameController;
   
    GameObject novaBala;
    void Start()
    {
        _gameController = (GameController)FindAnyObjectByType(typeof(GameController));
    }


    public void Lacar()
    {
        transform.position = _Pos.transform.position;
        _Rg.velocity = Vector2.zero;
        _Rg.AddForce(-transform.right * force, ForceMode2D.Impulse);
    }

    public void LacarTucano()
    {
        novaBala = Instantiate(gameObject);
        novaBala.transform.position = _Pos.transform.position;
        novaBala.transform.rotation = _Pos.transform.rotation;
        Rigidbody2D rbBala = novaBala.GetComponent<Rigidbody2D>();
        rbBala.velocity = Vector2.zero;
        rbBala.AddForce(novaBala.transform.right * force, ForceMode2D.Impulse);

        Destroy(novaBala, 1f);
    }
}