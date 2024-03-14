using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;

    private float nextSpaw = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpaw)
        {
            nextSpaw = Time.time + spawnRate;

            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
    }
}
