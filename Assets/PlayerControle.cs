using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControle : MonoBehaviour
{
    [SerializeField] Vector2 _move;
    [SerializeField] Rigidbody2D _rig;
    [SerializeField] float _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rig.velocity = new Vector2(_move.x, _rig.velocity.y);
    }
    public void SetMove(InputAction.CallbackContext value)
    {
        Vector2 m = value.ReadValue<Vector2>();
        _move.x= m.x;
        _move.y = m.y;
    }
}
