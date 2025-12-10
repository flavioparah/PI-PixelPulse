using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Limpei os usings desnecessários

public class Jump : MonoBehaviour
{
    public float _jumpForce, _JumpY = 10f;
    public LayerMask _groundLayer;
    public LayerMask _lastGroundLayer;
    public Transform _groundCheck;
    public float _groundCheckRadius = 0.1f;

    private bool _isGrounded;
    MovePlayer _movePlayer;

    public Collider2D _tucanoCollider;
    private bool _canMove = true;

    // Variável para evitar "pulo duplo" acidental ao segurar o analógico
    private bool _jumpWasPressed = false;

    void Start()
    {
        // FindObjectOfType é mais seguro que FindAnyObjectByType em versões antigas, 
        // mas mantive a lógica. Se der erro, troque para FindObjectOfType.
        _movePlayer = FindObjectOfType<MovePlayer>();
        _tucanoCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Atualiza valor apenas para debug, não afeta a lógica
        if (_movePlayer != null && _movePlayer._rig != null)
            _JumpY = _movePlayer._rig.velocity.y;

        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        // --- INPUTS ---
        // Pega o valor do eixo Vertical (-1 é baixo, 1 é cima, 0 é nada)
        // Isso cobre: W, S, Setas e Analógico Esquerdo do controle.
        float inputVertical = Input.GetAxisRaw("Vertical");

        // 1. LÓGICA DE PULO (Cima)
        // Verifica se apertou W OU se o analógico/seta está para cima (> 0.5f)
        bool tentouPular = Input.GetKeyDown(KeyCode.W) || (inputVertical > 0.5f);

        // Lógica extra para o analógico funcionar como um "clique" e não metralhadora
        if (tentouPular)
        {
            if (!_jumpWasPressed && _isGrounded)
            {
                _movePlayer._rig.velocity = new Vector2(_movePlayer._rig.velocity.x, _jumpForce);
                _jumpWasPressed = true; // Trava o pulo
            }
        }
        else
        {
            _jumpWasPressed = false; // Destrava quando solta o analógico/tecla
        }

        // 2. LÓGICA DE DESCER (Baixo)
        // Verifica S OU Seta Baixo OU Analógico para baixo (< -0.5f)
        // Nota: Input.GetKey é contínuo, assim como o analógico segurado
        bool tentouDescer = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || (inputVertical < -0.5f);

        if (tentouDescer && _isGrounded && _canMove)
        {
            _tucanoCollider.enabled = false;
            StartCoroutine(EnableCollisionAfterDelay());
        }
    }

    private IEnumerator EnableCollisionAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        _tucanoCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Terreo"))
        {
            _tucanoCollider.enabled = true;
            _canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Terreo"))
        {
            _canMove = true;
        }
    }
}