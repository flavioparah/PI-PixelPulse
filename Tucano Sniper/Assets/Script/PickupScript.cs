using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private Rigidbody2D _itemRb;

    float _pos;

    [SerializeField] ParticleSystem _partPepita;
    void Start()
    {
        _pos = Random.Range(-5f, 0f);

        _itemRb = GetComponent<Rigidbody2D>();
        _itemRb.AddForce(new Vector2(_pos, 5f),ForceMode2D.Impulse);

        _itemRb.AddForce(Vector2.left, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectItem();
        }

        if (collision.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }
    }

    private void CollectItem()
    {
        Destroy(gameObject);
        Instantiate(_partPepita, transform.position, Quaternion.identity);
    }

}