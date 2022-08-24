using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
     public float speed = 10;

    [SerializeField] private float objectDistance;

    [SerializeField] private float despawnDistance = -110f;

    public bool canSpawnGround = true;

    private Rigidbody rb;

    public static MoveGround instance;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameStarted==true&&GameManager.GameFailed==false&&GameManager.GameWined==false)
        {
            transform.position += -transform.forward * speed * Time.deltaTime;

            if (transform.position.z <= objectDistance && transform.tag == "Ground" && canSpawnGround)
            {

                ObjectSpawner.instance.SpawnGround();
                canSpawnGround = false;
            }

            if (transform.position.z <= despawnDistance)
            {
                canSpawnGround = true;
                gameObject.SetActive(false);
            }
        }
       
    }
  


    public void GameStarted()
    {

    }
    public void GameFailed()
    {

    }
    private void OnEnable()
    {
        //GameManager.gameManagerInstance.isGameStarted += GameStarted;
        //GameManager.gameManagerInstance.isGameFailed += GameFailed;
    }
    public void OnDisable()
    {
        GameManager.gameManagerInstance.isGameStarted -= GameStarted;
        GameManager.gameManagerInstance.isGameFailed -= GameFailed;
    }
}

