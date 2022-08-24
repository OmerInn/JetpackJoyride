using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Rocket : MonoBehaviour,ICollectible
{

    public static event Action OnCollectRocket;
    public float moveSpeed = 10f;

    public void Collect()
    {
        if (GameManager.GameDestroy == false)
        {
            GameManager.gameManagerInstance.OnFailed();
            OnCollectRocket?.Invoke();
        }
        else if (GameManager.GameDestroy == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.position-=Vector3.forward * moveSpeed * Time.deltaTime;
    }

}
