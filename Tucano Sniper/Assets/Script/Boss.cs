using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Boss : MonoBehaviour
{

    [SerializeField] ParticleSystem _hitBoss;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BalaTucano"))
        {
        
            Vector2 hitPoint = collision.contacts[0].point;

            Instantiate(_hitBoss, hitPoint, Quaternion.identity);

            Destroy(collision.gameObject);
        }
    }
}
