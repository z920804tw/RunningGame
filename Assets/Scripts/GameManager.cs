using System.Collections;
using System.Collections.Generic;
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
    public GameStatusType gameStatusType;
    public Platform firstPlatform;

    void Start()
    {
        gameStatusType = GameStatusType.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatusType == GameStatusType.None)
        {
            StarGame();
        }
    }

    public void StarGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStatusType = GameStatusType.Start;
            firstPlatform.isStop = false;
        }
    }

    public void EndGame()
    {
        gameStatusType=GameStatusType.End;
        GetComponent<GameOverUI>().GameOver();
    }
}
