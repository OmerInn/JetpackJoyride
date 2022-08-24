using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action isGameStarted;
    public event Action isGameEnded;
    public event Action isGameFailed;
    public event Action isGameWined;


    public static bool GameStarted = false;
    public static bool GameEnded = false;
    public static bool GameWined = false;
    public static bool GameFailed = false;
    public static bool GameDestroy = false;
    public static GameManager gameManagerInstance;

    private void Awake()
    {
        gameManagerInstance = this;
    }
    private void Start()
    {
        GameStarted = false;
        GameEnded = false;
        GameWined = false;
        GameFailed = false;
    }
    public void OnStarted()
    {
        if (isGameStarted != null)
        {
            GameStarted = true;
            isGameStarted();
        }

    }
    public void OnEnded()
    {
        if (isGameEnded != null)
        {
            GameEnded = true;
            isGameEnded();
        }

    }
    public void OnWined()
    {
        if (isGameWined != null)
        {
            GameWined = true;
            isGameWined();
        }


    }
    public void OnFailed()
    {
        if (isGameFailed != null)
        {
            GameFailed = true;
            isGameFailed();
        }

    }
    public IEnumerator OnDestroyer()
    {
        GameDestroy = true;
        PlayerManager.instance.Shield.SetActive(true);
        yield return new WaitForSeconds(5f);
        GameDestroy = false;
        PlayerManager.instance.Shield.SetActive(false);

    }

}
