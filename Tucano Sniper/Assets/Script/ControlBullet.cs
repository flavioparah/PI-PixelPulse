using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D _Rg;
    [SerializeField] float force;
    [SerializeField] Transform _Pos;
    void Start()
    {
        GameController.FindAnyObjectByType(typeof(GameController));
        //Lacar();
    }


    public void Lacar()
    {
        transform.position = _Pos.transform.position;
        _Rg.velocity = Vector2.zero;
        _Rg.AddForce(-transform.right * force , ForceMode2D.Impulse);
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
        if (collision.gameObject.CompareTag("Ground"))
        {
  
        }

        Debug.Log("Bala perdida");
    }



}
