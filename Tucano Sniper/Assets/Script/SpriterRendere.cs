using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriterRendere : MonoBehaviour
{
    public SpriteRenderer _Sprite;
    public bool _recovery = false;
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
        yield return new WaitForSeconds(0.2f);
        _Sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        _Sprite.color = new Color(0.8f, 0.3f, 0.3f, 1f);
        yield return new WaitForSeconds(0.2f);
        _Sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        _Sprite.color = new Color(0.8f, 0.3f, 0.3f, 1f);
        yield return new WaitForSeconds(0.2f);
        _Sprite.color = new Color(1, 1, 1, 1);
        
        _recovery = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que entrou em contato tem a tag desejada
        if (collision.gameObject.CompareTag("Bala"))
        {
            Hit();
            Debug.Log("Transparente");
        }
    }
}
