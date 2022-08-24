using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [Header("Coin System")]
    public TextMeshProUGUI CoinTxt;
    int CoinCount;

    public TextMeshProUGUI LvlTxt;
    int LevelCount=1;

    public List<GameObject> menuElement;

    public bool fingerToDestroyerBtn;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
            CoinCount = PlayerPrefs.GetInt("Gold");
            CoinTxt.text = "Coin: " + CoinCount;
        }
        else
        {
            CoinTxt.text = "Gold: 0";
        }

        if (PlayerPrefs.HasKey("Level"))
        {
            LevelCount = PlayerPrefs.GetInt("Level");
            LvlTxt.text = "Level: " + LevelCount;
        }
        else
        {
            LvlTxt.text = "Level: 1";
        }
        GameManager.gameManagerInstance.isGameWined += OnWined;//Ýsgamewined dinliyoruz
        GameManager.gameManagerInstance.isGameFailed += OnFailed;//Ýsgamewined dinliyoruz
        GameManager.gameManagerInstance.isGameStarted += OnStarted;//Ýsgamewined dinliyoruz
    }
    private void OnEnable()
    {
        Coin.OnCoinCollected += IncreGoldPoint;
    }
    private void OnDisable()
    {
        Coin.OnCoinCollected -= IncreGoldPoint;

    }
    public void StartTheGame()
    {
        GameManager.gameManagerInstance.OnStarted();
        

    }
    public void SetActivePanels()
    {
        menuElement.ForEach(x => x.SetActive(false));
    }

    public void OnStarted()
    {
        SetActivePanels();
        GameManager.gameManagerInstance.OnStarted();
    }
 
    public void OnFailed()
    {
        SetActivePanels();
        menuElement[1].SetActive(true);
    }
    public void OnWined()
    {
        SetActivePanels();
        menuElement[2].SetActive(true);
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLvlBtn()
    {
        LevelCount++;
        PlayerPrefs.SetInt("Level", LevelCount);
        LvlTxt.text = "Level: " + LevelCount;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void IncreGoldPoint()
    {
        CoinUp(5);
    }
    public void CoinUp(int amount)
    {
        CoinCount+=amount;
        PlayerPrefs.SetInt("Gold", CoinCount);
        CoinTxt.text = "Gold: " + CoinCount;
    }
    public void ObstacleDestroyer()
    {
        if (!fingerToDestroyerBtn)
        {
            fingerToDestroyerBtn = true;
            StartCoroutine(GameManager.gameManagerInstance.OnDestroyer());
        }

    }
    public void OnDestroy() // sahne bittiðinde dinlemeyi býrakýr.
    {
        GameManager.gameManagerInstance.isGameWined -= OnWined;//Ýsgamewined dinliyoruz
        GameManager.gameManagerInstance.isGameFailed -= OnFailed;//Ýsgamewined dinliyoruz
        GameManager.gameManagerInstance.isGameStarted -= OnStarted;//Ýsgamewined dinliyoruz
    }
}
