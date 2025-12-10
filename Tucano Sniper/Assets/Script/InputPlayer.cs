using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovePlayer))]
public class InputPlayer : MonoBehaviour
{
    [Header("Referência")]
    [SerializeField] private MovePlayer movePlayer;

   

    private void OnValidate()
    {
        // Garante que pegou o script MovePlayer
        if (movePlayer == null) movePlayer = GetComponent<MovePlayer>();
    }

    #region Input Events

    // 1. MOVIMENTO
    void OnMove(InputValue value)
    {
        if (movePlayer != null)
        {
            Vector2 inputVector = value.Get<Vector2>();
            // CORRIGIDO: Agora usa '_moveInput'
            movePlayer._moveInput = inputVector.x;
        }
    }

    // 2. MIRA
    void OnMira(InputValue value)
    {
        if (movePlayer != null)
        {
            // CORRIGIDO: Agora usa '_mousePositionInput'
            movePlayer._mousePositionInput = value.Get<Vector2>();
        }
    }

    // 3. TIRO
    void OnFire(InputValue value)
    {
        if (movePlayer != null)
        {
            // O value.isPressed retorna true quando segura e false quando solta
            movePlayer._fireInput = value.isPressed;

            // Adicione esta linha temporária para testar no Console da Unity:
            Debug.Log("Botão de Tiro: " + movePlayer._fireInput);
        }
    }


 

    #endregion
}