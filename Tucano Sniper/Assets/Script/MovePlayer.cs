using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class MovePlayer : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] float   _speed;
    [SerializeField] float   _JumpFoce;

    [Header("Components")]
    Animator        _anim;
    public Rigidbody2D     _rig;  
    private float   _moveH;
    bool            isFacingRight;
    bool            _checkGround;

    public Transform _chaoTemp;
    public Transform worldPosition;
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        anim();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition.position = Camera.main.ScreenToWorldPoint(mousePos);

    }

    private void FixedUpdate()
    {
        move();
        //Jump();
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

        if (_chaoTemp!=null && collision.gameObject.CompareTag("triggerChao"))
        {

            _chaoTemp.transform.position = new Vector2(_chaoTemp.transform.localPosition.x + 40f, _chaoTemp.transform.localPosition.y);
            Debug.Log("Passou");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;

        }
       
        if (collision.gameObject.CompareTag("triggerChao"))
        {
            _chaoTemp = collision.transform.parent;
            Debug.Log("saiu");
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
