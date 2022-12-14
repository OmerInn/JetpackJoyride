using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private bool spawningObject = false;

    [SerializeField] private float groundSpawnDistance;
    [SerializeField] private float rocketSpawnDistance;
    public GameObject FinishGround;
    public static ObjectSpawner instance;
    public int GroundSize;
    public int GroundTotalSize = 10;
    private void Awake()
    {
        instance = this;
    }
    public void SpawnGround()
    {
        if (GroundTotalSize > GroundSize)
        {
            GroundSize++;
            ObjectPool.instance.SpawnFromPool("ground", new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
        }
        else
        {
              Instantiate(FinishGround, new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
        }
       
    }
  
}
