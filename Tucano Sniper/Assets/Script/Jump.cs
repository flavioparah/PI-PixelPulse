using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float _jumpForce, _JumpY = 10f; // Força do pulo
    public LayerMask _groundLayer; // Camada do chão
    public LayerMask _lastGroundLayer;
    public Transform _groundCheck; // Transform do objeto que verifica se o personagem está no chão
    public float _groundCheckRadius = 0.1f; // Raio do círculo de verificação de colisão com o chão

    private bool _isGrounded;
    private bool _isLastGrounded;
    MovePlayer _movePlayer;

    public Collider2D _tucanoCollider;
    private bool _canMove = false;
   
    void Start()
    {
             _movePlayer = FindAnyObjectByType<MovePlayer>() as MovePlayer;
            _tucanoCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        _JumpY = _movePlayer._rig.velocity.y;

      
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

      
        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.S) && (_isGrounded || _isLastGrounded))
        {
                _movePlayer._rig.velocity = new Vector2(_movePlayer._rig.velocity.x, _jumpForce);
                
        }

        _isLastGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _lastGroundLayer);


        if (((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Input.GetKeyDown(KeyCode.Space)) && _isGrounded && !_isLastGrounded && !_canMove)
         {

                _tucanoCollider.enabled = false;

                _canMove = true;

                StartCoroutine(tucanoCollisionDelay());
         }

    }

    private IEnumerator tucanoCollisionDelay()
    {

        yield return new WaitForSeconds(0.2f);

        _tucanoCollider.enabled = true;

        yield return new WaitForSeconds(0.24f);

        _canMove = false;

    }
}
