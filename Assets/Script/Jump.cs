using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float _jumpForce = 10f; // Força do pulo
    public LayerMask _groundLayer; // Camada do chão
    public Transform _groundCheck; // Transform do objeto que verifica se o personagem está no chão
    public float _groundCheckRadius = 0.1f; // Raio do círculo de verificação de colisão com o chão

    private bool _isGrounded;
    MovePlayer _movePlayer;

    void Start()
    {
             _movePlayer = FindAnyObjectByType<MovePlayer>() as MovePlayer; 
    }

    void Update()
    {
        // Verifica se o personagem está no chão
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        // Verifica se o jogador pressionou a tecla de espaço e se o personagem está no chão
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            // Aplica uma força vertical para fazer o personagem pular
            _movePlayer._rig.velocity = new Vector2(_movePlayer._rig.velocity.x, _jumpForce);
        }
    }
}
