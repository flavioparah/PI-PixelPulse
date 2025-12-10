using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    // ----------------------------------------------------------
    //  INPUTS
    // ----------------------------------------------------------
    [HideInInspector] public float _moveInput;
    [HideInInspector] public Vector2 _mousePositionInput;
    [HideInInspector] public bool _fireInput;

    // ----------------------------------------------------------
    //  Atributos
    // ----------------------------------------------------------
    [Header("Atributos")]
    [SerializeField] float _speed = 5f;
    [SerializeField] float _distanciaMiraControle = 3f;
    [SerializeField] float _suavidadeMira = 20f; 

    public float _suavidadeMouse = 20f;    
    public float _suavidadeControle = 5f;

    // ----------------------------------------------------------
    //  Componentes
    // ----------------------------------------------------------
    [Header("Componentes")]
    Animator _anim;
    public Rigidbody2D _rig;
    GameController _gameController;

    [Header("Controle de Mira")]
    public Transform worldPosition;

    [Header("Ataque")]
    [SerializeField] ControlBullet _ControlBullet;

    // ----------------------------------------------------------
    //  BOLEANAS
    // ----------------------------------------------------------
    bool _Hit;
    bool _colisaoDetectada = false;
    bool isInvincible = false;

    // Variável para guardar onde a mira deve ir
    private Vector3 _targetAimPosition;

    [Header("Efeitos")]
    [SerializeField] Transform _transformFum;
    [SerializeField] Transform _transformTucano;
    [SerializeField] GameObject _FumacaTucano;

    void Start()
    {
        _gameController = GameController.instance;

        if (_ControlBullet == null)
        {
            GameObject bulletObj = GameObject.FindWithTag("ControlBullet");
            if (bulletObj != null) _ControlBullet = bulletObj.GetComponent<ControlBullet>();
        }

        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        // Inicializa a mira na posição atual para não pular no começo
        if (worldPosition != null) _targetAimPosition = worldPosition.position;
    }

    void Update()
    {
        AtualizarAnimacoes();
        VerificarGameOver();

        // MIRA VEM PARA O UPDATE (Para ficar fluido visualmente)
        ControleMiraETiro();
    }

    void FixedUpdate()
    {
        // MOVIMENTO FICA NO FIXEDUPDATE (Para física correta)
        MoverJogador();
    }

    void MoverJogador()
    {
        _rig.velocity = new Vector2(_moveInput * _speed, _rig.velocity.y);
    }

    // ----------------------------------------------------------
    //  LÓGICA DE MIRA 
    // ----------------------------------------------------------
    void ControleMiraETiro()
    {
        if (worldPosition != null)
        {
            float suavidadeAtual = _suavidadeMira; // Valor padrão

            // 1. Lógica de Input
            if (_mousePositionInput.magnitude > 2.0f)
            {
                // --- MODO MOUSE ---
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(_mousePositionInput);
                mousePos.z = 0;
                _targetAimPosition = mousePos;

                // O mouse deve ser ágil
                suavidadeAtual = _suavidadeMouse;
            }
            else if (_mousePositionInput.magnitude > 0.1f)
            {
                // --- MODO JOYSTICK ---
                Vector3 direcaoInput = new Vector3(_mousePositionInput.x, _mousePositionInput.y, 0);

                // AQUI ESTÁ O TRUQUE:
                // Multiplicamos a direção pela distância máxima desejada.
                // O ClampMagnitude impede que vá longe demais, mas permite mirar perto se inclinar pouco.
                Vector3 offsetMira = Vector3.ClampMagnitude(direcaoInput * _distanciaMiraControle, _distanciaMiraControle);

                _targetAimPosition = transform.position + offsetMira;

                // O controle precisa ser mais "pesado" para evitar tremedeira
                suavidadeAtual = _suavidadeControle;
            }

            // Se soltar o analógico, você pode manter o _targetAimPosition onde estava 
            // ou resetar para o player (opcional)

            // 2. Move a mira suavemente usando a suavidade correta para o dispositivo atual
            worldPosition.position = Vector3.Lerp(worldPosition.position, _targetAimPosition, suavidadeAtual * Time.deltaTime);
        }

        // Tiro
        if (_fireInput && _ControlBullet != null)
        {
            _ControlBullet.Shoot();
        }
    }

    void AtualizarAnimacoes()
    {
        float correr = Mathf.Abs(_moveInput);
        _anim.SetFloat("correr", correr);
        _anim.SetBool("Hit", _Hit);
        _anim.SetFloat("VelocidadeY", _rig.velocity.y);
    }

    // ... (O resto do código de colisão e dano continua igual) ...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala") && !isInvincible)
        {
            isInvincible = true;
            if (_gameController != null) _gameController._Life--;
            _Hit = true;
            StartCoroutine(PlayerInvencibilidade());
        }
        if (collision.CompareTag("Exit")) SceneManager.LoadScene("Score-screen");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala")) { _colisaoDetectada = false; _Hit = false; }
    }

    IEnumerator PlayerInvencibilidade()
    {
        yield return new WaitForSeconds(0.2f);
        _Hit = false;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }

    void VerificarGameOver()
    {
        if (_gameController != null && _gameController._Life <= 0)
        {
            _colisaoDetectada = true;
            _Hit = true;
            StartCoroutine(ShowGameOverRoutine());
        }
    }

    IEnumerator ShowGameOverRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        if (_FumacaTucano != null) _FumacaTucano.SetActive(true);
        if (_gameController != null) _gameController.ShowGamerOver();
    }

    public void Dead()
    {
        if (_gameController != null && _gameController._Life <= 0)
        {
            Destroy(gameObject);
            if (_FumacaTucano != null) _FumacaTucano.SetActive(true);
        }
    }
}