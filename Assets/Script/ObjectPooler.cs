using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string _type;

        public GameObject _Prefab;

        public int _Size;
    }

    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    GameObject objectToSpawn;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>> ();

        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for (int i = 0; i < pool._Size; i++) 
            {
                GameObject obj = Instantiate(pool._Prefab);
                obj.SetActive(false);
                objectsPool.Enqueue (obj);
            }

            poolDictionary.Add (pool._type, objectsPool);   

        }

        GameObject SpawnFromPool (string type, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(type)) 
            {
                Debug.LogWarning("Pool With type: " + type + " doesn't exist.");
                return null; 
            }

            objectToSpawn = poolDictionary[type].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            poolDictionary[type].Enqueue (objectToSpawn);

            return objectToSpawn;
        }
    }
}
