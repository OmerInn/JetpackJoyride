using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Finish : MonoBehaviour, ICollectible
{
    public static event Action OnCollectFinish;

    public void Collect()
    {
        GameManager.gameManagerInstance.OnWined();
        OnCollectFinish?.Invoke();
    }
}
