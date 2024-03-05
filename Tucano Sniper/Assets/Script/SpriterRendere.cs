using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriterRendere : MonoBehaviour
{
    public SpriteRenderer _Sprite;
    public bool _recovery = false;
    bool _colisaoDetectada = false;
    bool _Hit;
    void Start()
    {
        _Sprite = GetComponent<SpriteRenderer>();
           
    }
    public void Hit()
    {
        if (_recovery == false)
        {
            StartCoroutine(Flick());
        }
    }
    IEnumerator Flick()
    {
        _recovery = true;
        _Sprite.color = new Color(0.8f, 0.3f, 0.3f, 1f);
        yield return new WaitForSeconds(0.1f);
        _Sprite.color = new Color(1, 1, 1, 1);
       
        
        _recovery = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Bala") && !_colisaoDetectada)
        {
     
            _colisaoDetectada = true;
            Hit();

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bala"))
        {
            _colisaoDetectada = false;

        }

        
    }
}
