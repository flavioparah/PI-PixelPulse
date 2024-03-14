using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    public bool start;
    private float nextSpaw = 0f;


    void Start()
    {
        Invoke("timeStart", spawnRate);

    }
    void Update()
    {
        if (start == true)
        {

        

        if (Time.time > nextSpaw)
        {
            nextSpaw = Time.time + spawnRate;

            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }

        }
    }
    void timeStart()
    {
        start = true;

    }
   
   
}
