using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Animator _GunAnim;
    [SerializeField] private Transform _Gun;
    [SerializeField] private float _GunDistance;
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        _Gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _Gun.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(_GunDistance, 0, 0);


        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    public void Shoot() 
    {
        _GunAnim.SetTrigger("Shoot");
    }
}
