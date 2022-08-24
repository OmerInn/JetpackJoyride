using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    [Header("RandomRocket")]
    public Vector3 spawnValues;
    public GameObject rocket;
    public bool stop;
    public bool SpawnTime;
    public float spawnWait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameStarted == true && GameManager.GameFailed == false && GameManager.GameWined == false)
        {
            if (!stop)
            {
                StartCoroutine(waitSpawner());
            }



        }
    }
    IEnumerator waitSpawner()
    {

            if (!SpawnTime)
            {
                SpawnTime = true;
                Vector3 spawnPos = new Vector3(0, Random.Range(5, spawnValues.y), spawnValues.z);
                Instantiate(rocket, spawnPos, rocket.transform.rotation);
                spawnWait = Random.Range(3, 7);
                yield return new WaitForSeconds(spawnWait);
                SpawnTime = false;
            }
           
    }
}
