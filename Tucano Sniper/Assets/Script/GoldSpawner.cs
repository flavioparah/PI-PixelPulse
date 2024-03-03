using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject _goldPrefab; // Prefab do ouro
    public float _dropTime = 5f; // Tempo antes do ouro desaparecer
    private bool _isDead = false;
    public float upwardForce = 5f;
    public Transform _PivotOuro;
    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
  

        if (collision.gameObject.CompareTag("BalaTucano"))
        {

            MoveEnemy.instance._Life = MoveEnemy.instance._Life - 1;
        }

    }

    public void Die()
    {
        if (!_isDead)
        {
            _goldPrefab.SetActive(true);
            _isDead = true;
            DropGold();
            Invoke("RemoveGold", _dropTime);
        }

        if (MoveEnemy.instance._Life <= 0)
        {
            Die();
        }
    }


    void DropGold()
    {
        Instantiate(_goldPrefab, _PivotOuro.transform.position, Quaternion.identity);
       

        Drop();

    }


    void RemoveGold()
    {

        GameObject[] goldObjects = GameObject.FindGameObjectsWithTag("Gold");
        foreach (GameObject gold in goldObjects)
        {
            Destroy(gold);
        }
    }

    public void Drop()
    {

        if (_rigidbody != null)
        {
            _rigidbody.AddForce(Vector3.up * upwardForce, ForceMode2D.Impulse);
        }
    }
}

