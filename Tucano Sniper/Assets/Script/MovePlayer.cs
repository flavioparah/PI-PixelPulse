using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] float _speed = 5;
    //[SerializeField] float _JumpFoce = 5;
    [SerializeField] float _moveH;

    [Header("Components")]
    Animator _anim;
    public Rigidbody2D _rig;

    bool _Hit;
    bool _colisaoDetectada = false;
    bool isInvincible = false;

    public Transform worldPosition;

    [SerializeField] ControlBullet _ControlBullet;

    GameController _gameController;

    [SerializeField] Transform _transformFum;
    [SerializeField] Transform _transformTucano;
    [SerializeField] GameObject _FumacaTucano;

    void Start()
    {
        _gameController = GameController.instance;
        _ControlBullet = GameObject.FindWithTag("ControlBullet").GetComponent<ControlBullet>();

        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim();
        showGameOverM();
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        worldPosition.position = mousePos;

        if (Input.GetButton("Fire1"))
        {
            _ControlBullet.Shoot();
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
        if (collision.CompareTag("Bala") && !isInvincible)
        {
            isInvincible = true;
            _gameController._Life--;
            _Hit = true;

         

            StartCoroutine(PlayerInvencibilidade());
        }

        if (collision.CompareTag("Exit"))
        {
            SceneManager.LoadScene("Score-screen");
        }
    }

    IEnumerator PlayerInvencibilidade()
    {
        // tempo animado com hit
        yield return new WaitForSeconds(0.2f);
        _Hit = false;

        // tempo imune
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            _colisaoDetectada = false;
            _Hit = false;
        }
    }

    void showGameOverM()
    {
        if (_gameController._Life <= 0)
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

        _FumacaTucano.SetActive(true);

        _gameController.ShowGamerOver();
    }

    public void Dead()
    {
        if (_gameController._Life <= 0)
        {
            Destroy(gameObject);
            _FumacaTucano.SetActive(true);
        }
    }
}
