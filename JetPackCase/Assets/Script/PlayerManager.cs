using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Movement")]

    [Space(2)]
    public Rigidbody rb;
    public int force = 15;
    public static PlayerManager instance;
    public GameObject Shield;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.GameStarted == true && !GameManager.GameFailed && !GameManager.GameWined)
        {

       
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(new Vector3(0, force, 0), ForceMode.Acceleration);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                rb.velocity *=.25f;
            }
        }
    }
    private void OnEnable()
    {
        WallObstacle.OnCollectWall += WallDetected;
    }
    private void OnDisable()
    {
        WallObstacle.OnCollectWall -= WallDetected;

    }
    public void OnWined()
    {
        
    }
    public void OnFailed()
    {
        
    }
    public void OnStarted()
    {
      
    }
    public void WallDetected()
    {
        MoveGround.instance.speed = 0;
    }

    public void OnDestroy() // sahne bittiðinde dinlemeyi býrakýr.
    {
        GameManager.gameManagerInstance.isGameWined -= OnWined;//Ýsgamewined dinliyoruz
        GameManager.gameManagerInstance.isGameFailed -= OnFailed;//Ýsgamewined dinliyoruz
        GameManager.gameManagerInstance.isGameStarted -= OnStarted;//Ýsgamewined dinliyoruz
    }
}
