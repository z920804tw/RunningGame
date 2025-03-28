using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum GameStatusType
{
    None = 0,
    Start = 1,
    End = 2,
}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlatformManager platformManager;
    public GameStatusType gameStatusType;
    public PlatformState platformState;
    public GameObject StartCam;
    public Animator PlayrAnim;
    public Platform firstPlatform;

    GameStatusUI gameStatusUI;
    void Start()
    {
        gameStatusType = GameStatusType.None;
        gameStatusUI = GetComponent<GameStatusUI>();
        platformState = PlatformState.State1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatusType == GameStatusType.End) return;

        if (gameStatusType == GameStatusType.Start)
        {
            if (platformState == PlatformState.State1 && gameStatusUI.Timer >= 100f && gameStatusUI.Timer <= 180f)
            {
                platformState = PlatformState.State2;
                platformManager.platformSpeed = 8;

                GameObject[] currentPlatform = GameObject.FindGameObjectsWithTag("Platform");
                foreach (GameObject i in currentPlatform)
                {
                    i.GetComponent<Platform>().MoveSpeed = platformManager.platformSpeed;
                }
            }
            else if (platformState == PlatformState.State2 && gameStatusUI.Timer > 180)
            {
                platformState = PlatformState.State3;
                platformManager.platformSpeed = 9;
                GameObject[] currentPlatform = GameObject.FindGameObjectsWithTag("Platform");
                foreach (GameObject i in currentPlatform)
                {
                    i.GetComponent<Platform>().MoveSpeed = platformManager.platformSpeed;
                }
            }
        }

        if (gameStatusType == GameStatusType.None)
        {
            StarGame();
        }

    }

    public void StarGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCam.SetActive(false);
            gameStatusUI.startHintText.text = string.Empty;
            StartCoroutine(DelayStart(4));
        }
    }

    public void EndGame()
    {
        gameStatusType = GameStatusType.End;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject i in platforms)
        {
            i.GetComponent<Platform>().isStop = true;
        }
        GetComponent<GameOverUI>().GameOver();
    }

    IEnumerator DelayStart(float t)
    {
        float timer = t;
        gameStatusUI.statusText.text = $"{(int)timer}";
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            gameStatusUI.statusText.text = $"{(int)timer}";
            yield return null;
        }

        gameStatusType = GameStatusType.Start;
        gameStatusUI.statusText.text = $"Start!";
        PlayrAnim.SetTrigger("Start");
        firstPlatform.isStop = false;

        gameStatusUI.levelStatusUI.SetActive(true);


        yield return new WaitForSeconds(1f);
        gameStatusUI.statusText.text = string.Empty;

    }
}
