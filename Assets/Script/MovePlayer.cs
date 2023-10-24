using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D _rig;
    [SerializeField] float _speed;
    [SerializeField] float _moveH;
    [SerializeField] bool _checkGround;
    bool isFacingRight;
    Animator _anim;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        _moveH = Input.GetAxisRaw("Horizontal");

        float correr = Mathf.Abs(_moveH); 

        _rig.velocity = new Vector2 ( _moveH * _speed, _rig.velocity.y);

        _anim.SetFloat("correr", correr);

        if(-_moveH<0 && isFacingRight == true)
        {
            Flip();
        }

        else if(-_moveH > 0 && isFacingRight == false)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = true; 
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;

        }
    }
    void Flip ()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
