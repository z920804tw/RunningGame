using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatusUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("關卡狀態")]
    public TMP_Text timerText;
    public TMP_Text coinText;
    float timer;
    int coinCount;
    [Header("玩家狀態")]
    public PlayerHealth playerHealth;
    public GameObject hpBar;
    public TMP_Text hpText;
    public GameObject healthPrefab;

    [Header("場景UI")]
    public GameObject pauseUI;
    bool isPause;
    void Start()
    {
        timer = 0;
        coinCount = 0;
        coinText.text = $"x{coinCount}";

        isPause=false;
    }

    void Update()
    {
        if (playerHealth.IsDead) return;

        timer += Time.deltaTime;
        timerText.text = $"時間:{(int)timer}s";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUiStatus();
        }

    }

    public void UpdateCoin()
    {
        coinCount++;
        coinText.text = $"x{coinCount}";
    }

    public void DecreaseHpUI(int i)
    {
        if (i != 999)  //不是999的代表就是不會馬上死，如果傳入的值是999代表即死
        {
            hpText.text = $"HP:{playerHealth.CurrentHp}/{playerHealth.maxHp}";
            for (int j = 0; j < i; j++)
            {
                GameObject last = hpBar.transform.GetChild(hpBar.transform.childCount - 1).gameObject;
                Destroy(last);
            }
        }
        else
        {
            hpText.text = $"HP:{0}/{playerHealth.maxHp}";
            for (int j = hpBar.transform.childCount; j > 0; j--)
            {
                GameObject health = hpBar.transform.GetChild(j - 1).gameObject;
                Destroy(health);
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
        }

    }

    void PauseUiStatus()
    {
        if (isPause)
        {
            //關閉
            pauseUI.SetActive(false);
            Time.timeScale=1;
        }
        else
        {
            pauseUI.SetActive(true);
            Time.timeScale=0;   
        }
        isPause=!isPause;
    }


}
