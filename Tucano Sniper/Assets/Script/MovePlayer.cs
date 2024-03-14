using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class MovePlayer : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] float   _speed;
    [SerializeField] float   _JumpFoce;
    [SerializeField] float _moveH;

    [Header("Components")]
    Animator               _anim;
    public Rigidbody2D     _rig;
    [SerializeField] GameObject _FumacaTucano;

    bool            isFacingRight;
    bool            _Hit;
    bool            _colisaoDetectada = false;

    public Transform worldPosition;

    [SerializeField] ControlBullet _ControlBullet;

    public static MovePlayer instance;
    GameController _gameController;

    [SerializeField] Transform _transformFum;
    [SerializeField] Transform _transformTucano;

    void Start()
    {
        _gameController = (GameController)FindAnyObjectByType(typeof(GameController));

        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        

    }

    
    void Update()
    {
        anim();
        showGameOverM();
       // _transformFum.position = new Vector2(_transformTucano.position.x, _transformTucano.position.y);

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

      

        
    }

    public void MouseControl() 
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition.position = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetButtonDown("Fire1"))
        {
            _ControlBullet.LacarTucano();
        }

    }

    public void anim() 
    {
        float correr = Mathf.Abs(_moveH);
      _anim.SetFloat("correr", correr);
      _anim.SetBool("Hit", _Hit);
      _anim.SetFloat("VelocidadeY", _rig.velocity.y);
      
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.CompareTag("Bala") && !_colisaoDetectada)
        {
            _gameController._Life -= 1;
            _colisaoDetectada = true;
            _Hit = true;      

        }       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
               
        if (collision.gameObject.CompareTag("Bala"))
        {
            _colisaoDetectada = false;
          
        }

        if (collision.gameObject.CompareTag("Bala"))
        {          
            _Hit = false;         
        }
    }

    void showGameOverM()
    {
        if ( GameController.instance._Life <= 0)
        {
            _colisaoDetectada = true;
            _Hit = true;

            StartCoroutine(timeShowGameOver());
           
        }
    }
    IEnumerator timeShowGameOver()
    {
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);

        GameController.instance.ShowGamerOver();
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
        //if (_checkGround == true )
        {
            //_rig.velocity = new Vector2(_rig.velocity.x, 0);
            //_rig.AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
        }
    }

    public void Dead()
    {
        if (GameController.instance. _Life <= 0)
        {
            Destroy(gameObject);
            _FumacaTucano.SetActive(true);
        }

    }


}
