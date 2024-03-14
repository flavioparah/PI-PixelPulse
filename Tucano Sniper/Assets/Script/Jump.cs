using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float _jumpForce, _JumpY = 10f; // For�a do pulo
    public LayerMask _groundLayer; // Camada do ch�o
    public LayerMask _lastGroundLayer;
    public Transform _groundCheck; // Transform do objeto que verifica se o personagem est� no ch�o
    public float _groundCheckRadius = 0.1f; // Raio do c�rculo de verifica��o de colis�o com o ch�o

    private bool _isGrounded;
    MovePlayer _movePlayer;

    public Collider2D _tucanoCollider;
    private bool _canMove = true;
   
    void Start()
    {
             _movePlayer = FindAnyObjectByType<MovePlayer>() as MovePlayer;
            _tucanoCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        _JumpY = _movePlayer._rig.velocity.y;

      
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

      
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
                _movePlayer._rig.velocity = new Vector2(_movePlayer._rig.velocity.x, _jumpForce);
                
        }


        if (((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) && _isGrounded && _canMove)
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
