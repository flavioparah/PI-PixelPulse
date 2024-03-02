using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MovePlayer : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] float   _speed;
    [SerializeField] float   _JumpFoce;

    [Header("Components")]
    public Animator        _anim;
    public Rigidbody2D     _rig;  
    private float   _moveH;
    bool            isFacingRight;
    bool            _checkGround;
    bool            _Hit;
    bool            _colisaoDetectada = false;

    public Transform worldPosition;

    [SerializeField] ControlBullet _ControlBullet;

    public static MovePlayer instance;
    GameController _gameController;

    void Start()
    {
        _gameController = (GameController)FindAnyObjectByType(typeof(GameController));

        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
       
    }

    
    void Update()
    {
        anim();
      

    }

    private void FixedUpdate()
    {
        move();
        MouseControl();
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

    public void MouseControl() 
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition.position = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition);
            _ControlBullet.LacarTucano();
        }

    }

    public void anim() 
    {
        float correr = Mathf.Abs(_moveH);
      _anim.SetFloat("correr", correr);
      _anim.SetBool("Pulo", _checkGround);
      _anim.SetFloat("VelocidadeY", _rig.velocity.y);
  
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala") && GameController.instance._Life <= 0)
        {
            GameController.instance.ShowGamerOver();
            Destroy(gameObject);
            Time.timeScale = 0f;        
        }

        if (!_colisaoDetectada && collision.gameObject.CompareTag("Bala"))
        {
            _gameController._Life -= 1;
            _colisaoDetectada = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
               

        if (collision.gameObject.CompareTag("Bala"))
        {
            _colisaoDetectada = false;
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
