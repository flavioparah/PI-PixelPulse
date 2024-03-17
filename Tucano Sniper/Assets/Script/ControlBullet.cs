using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ControlBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D _Rg;
    [SerializeField] float force;
    [SerializeField] Transform _Pos;
   
    GameObject novaBala;

    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem _fumacaEnemy;

    [SerializeField] GameObject _item;

    public static ControlBullet instance;

    void Start()
    {
        instance = this;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))

        {
            Vector2 hitPoint = collision.ClosestPoint(transform.position);

            Instantiate(particles, hitPoint, Quaternion.identity);

        }
    }


    public void effectEnemy(Transform posEnemy)
    {
        Instantiate(_fumacaEnemy, new Vector2(posEnemy.position.x, posEnemy.position.y + 1f), Quaternion.identity);

        Instantiate(_item, posEnemy.position, Quaternion.identity);
        Instantiate(_item, posEnemy.position, Quaternion.identity);

    }

}