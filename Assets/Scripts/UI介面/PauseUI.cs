using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("場景UI")]
    public GameManager gameManager;
    public LoadingUI loadingUI;
    public GameObject pauseUI;
    public GameObject[] pausePages;
    bool isPaused;
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStatusType == GameStatusType.End) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUiStatus();
        }
    }
    public void PauseUiStatus()
    {
        if (isPaused)
        {
            //關閉
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        isPaused = !isPaused;
    }

    public void OpenPage(int i)
    {
        CloseAll();
        pausePages[i].SetActive(true);
    }

    void CloseAll()
    {
        foreach (GameObject i in pausePages)
        {
            i.SetActive(false);
        }
    }
    public void BackToLobby()
    {
        loadingUI.Load(0);
    }
}
