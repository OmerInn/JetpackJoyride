using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string type;
        public List<GameObject> prefabs;
        public int size;
       
    }
    public static ObjectPool instance;

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    GameObject objectToSpawn;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabs[Random.Range(0,pool.prefabs.Count)]);
                obj.SetActive(false);
                objectPool.Enqueue(obj);

            }

            poolDictionary.Add(pool.type, objectPool);
        }
    }

    public GameObject SpawnFromPool(string type , Vector3 position ,Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(type))
        {
            Debug.Log("Pool with type: " + type + "doesnt exit");
           
        }

        objectToSpawn = poolDictionary[type].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[type].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
