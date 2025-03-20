using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [Header("遊戲結束UI內容")]
    public GameObject gameOverUI;
    public TMP_Text endTime;
    public TMP_Text endDistance;
    public TMP_Text endCoin;

    GameStatusUI gameStatusUI;
    // Start is called before the first frame update
    void Start()
    {
        gameStatusUI=GetComponent<GameStatusUI>();  
    }

    public void GameOver()
    {
        StartCoroutine(DelayOpen(gameOverUI, 2f));

        //設定結束數據
        endTime.text = $"遊玩時間:{(int)gameStatusUI.Timer}s";
        endDistance.text = $"距離:{(int)gameStatusUI.Distance}m";
        endCoin.text = $"x{gameStatusUI.CoinCount}";
    }
    IEnumerator DelayOpen(GameObject obj, float delayTime)
    {

        yield return new WaitForSeconds(delayTime);
        obj.SetActive(true);
    }
}
