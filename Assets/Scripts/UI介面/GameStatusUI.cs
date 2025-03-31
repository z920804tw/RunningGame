using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatusUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("關卡狀態")]
    public GameObject levelStatusUI;
    public TMP_Text statusText;
    public TMP_Text startHintText;
    [Header("遊玩狀態")]
    public GameManager gameManager;
    public PlatformManager platformManager;
    public TMP_Text distanceText;
    public TMP_Text timerText;
    public TMP_Text coinText;
    float timer;
    float distance;
    int coinCount;

    public float Timer { get { return timer; } }
    public float Distance { get { return distance; } }
    public int CoinCount { get { return coinCount; } }
    [Header("玩家狀態")]
    public PlayerHealth playerHealth;
    public GameObject hpBar;
    public TMP_Text hpText;
    public GameObject healthPrefab;

    void Start()
    {
        timer = 0;
        coinCount = 0;
        coinText.text = $"x{coinCount}";
    }

    void Update()
    {
        if (gameManager.gameStatusType == GameStatusType.End ||
            gameManager.gameStatusType == GameStatusType.None) return;

        timer += Time.deltaTime;
        timerText.text = $"時間:{(int)timer}s";

        distance += platformManager.platformSpeed / 2 * Time.deltaTime;
        distanceText.text = $"距離:{(int)distance}m";


    }

    public void UpdateCoin() //更新金幣
    {
        coinCount++;
        coinText.text = $"x{coinCount}";
    }

    public void DecreaseHpUI(int i)
    {
        if (i == 999)  //不是999的代表就是不會馬上死，如果傳入的值是999代表即死
        {

            hpText.text = $"HP:{0}/{playerHealth.maxHp}";
            for (int j = hpBar.transform.childCount-1; j >= 0; j--)
            {
                GameObject health = hpBar.transform.GetChild(j).gameObject;
                Destroy(health);
            }
        }
        else
        {
            hpText.text = $"HP:{playerHealth.CurrentHp}/{playerHealth.maxHp}";
            for (int j = 0; j < i; j++)
            {
                GameObject last = hpBar.transform.GetChild(hpBar.transform.childCount - 1).gameObject;
                Destroy(last);
            }
        }
    }
    public void IncreaseHpUI(int i)
    {
        hpText.text = $"HP:{playerHealth.CurrentHp}/{playerHealth.maxHp}";
        for (int j = 0; j < i; j++)
        {
            GameObject add = Instantiate(healthPrefab, transform.position, Quaternion.identity);
            add.transform.SetParent(hpBar.transform);
            add.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
    }
}
