using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private ScriptGround _scriptGround;

    [SerializeField] bool _ChaoInstranciado = false;
    void Start()
    {
        _scriptGround = FindObjectOfType(typeof(ScriptGround)) as ScriptGround;
    } 

    void Update()
    {
        if(_ChaoInstranciado == false) 
        {
           if(transform.position.x <= 0) 
            {
                _ChaoInstranciado = true;
                GameObject ObjectTemporarioChao = Instantiate(_scriptGround._GroundPrefab);
                ObjectTemporarioChao.transform.position = new Vector2(transform.position.x + _scriptGround._GroundSize, transform.position.y);
                Debug.Log("O chao foi instaciado");
            }
        }

        if (transform.position.x < _scriptGround._GroundDestroy) 
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        transform.Translate(Vector2.left * _scriptGround._GroundVelocity * Time.deltaTime);
    }
}
