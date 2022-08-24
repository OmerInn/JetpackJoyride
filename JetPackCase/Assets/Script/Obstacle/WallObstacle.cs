using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WallObstacle : MonoBehaviour, ICollectible
{
    public static event Action OnCollectWall;
    public bool active=true;
    public void Collect()
    {
        if (GameManager.GameDestroy==false)
        {
             GameManager.gameManagerInstance.OnFailed();
             OnCollectWall?.Invoke();
        }
        else if (GameManager.GameDestroy == true)
        {
            this.gameObject.SetActive(false);
        }
    }


}
