using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] float   _speed;
    [SerializeField] float   _JumpFoce;

    [Header("Components")]
    Animator        _anim;
    Rigidbody2D     _rig;

    private float   _moveH;
    bool            isFacingRight;
    bool            _checkGround;
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim();
    }

    private void FixedUpdate()
    {
        move();
        Jump();
    }

    void move() 
    {
        _moveH = Input.GetAxisRaw("Horizontal");

        _rig.velocity = new Vector2(_moveH * _speed, _rig.velocity.y);

        if (_moveH > 0 && isFacingRight == true)
        {
            Flip();
        }

        else if (_moveH < 0 && isFacingRight == false)
        {
            Flip();
        }
    }

    void Jump() 
    {
        if (_checkGround == true && Input.GetAxisRaw("Jump") > 0 )
        {
            _rig.velocity = new Vector2(_rig.velocity.x, 0);
            _rig.AddForce(new Vector2(0, _JumpFoce), ForceMode2D.Impulse);
        }
    }

    void anim() 
    {
        float correr = Mathf.Abs(_moveH);
      _anim.SetFloat("correr", correr);
      _anim.SetBool("Pulo", _checkGround);
      _anim.SetFloat("VelocidadeY", _rig.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    public void SetMovimento(InputAction.CallbackContext value)
    {
        move();
    }

    public void SetPulo (InputAction.CallbackContext value)
    { 
        JumpC();
    }
    void JumpC()
    {
        if (_checkGround == true )
        {
            _rig.velocity = new Vector2(_rig.velocity.x, 0);
            _rig.AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
        }
    }


}
