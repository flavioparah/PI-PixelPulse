using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;
using static UnityEditor.Progress;

public class GroundControl : MonoBehaviour
{
    public Transform gbase; 
    public GameObject gtemp;
    [SerializeField] float speed = 5f;
    private GroundController _groundController;


    void Start()
    {
        //CallEnemies();
        gtemp = gbase.gameObject;
        for (int i = 0; i < 2; i++)
        {
            Invoke("CallGround", 1);
        }

     
    }
  
    public void CallGround()
    {
        GameObject bullet = Ground.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.localPosition = new Vector2(gtemp.transform.localPosition.x+ 40f, gtemp.transform.localPosition.y);
            gtemp = bullet;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //bullet.transform.rotation = turret.transform.rotation;
            bullet.SetActive(true);          
        }
    }
   
}
