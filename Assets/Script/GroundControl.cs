using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GroundControl : MonoBehaviour
{
    public Transform gbase; 
    public GameObject gtemp;
    private void Start()
    {
        //CallEnemies();
        gtemp = gbase.gameObject;
        for (int i = 0; i < 2; i++)
        {
            Invoke("CallEnemies", 1);
        }
      
    }
    public void CallEnemies()
    {
        GameObject bullet = Ground.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.localPosition = new Vector2(gtemp.transform.localPosition.x+ 40.03f, gtemp.transform.localPosition.y);
            gtemp = bullet;
            //bullet.transform.rotation = turret.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
