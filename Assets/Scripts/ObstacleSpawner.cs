using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("物件設定")]
    public Transform parent;
    public bool isRandom;
    public List<GameObject> obstaclePrefabs;


    void Start()
    {
        if (isRandom) //隨機開關
        {
            obstaclePrefabs.Clear();
            float count = parent.childCount;
            float rnd = 0f;
            for (int i = 0; i < count; i++) //新增物件
            {
                obstaclePrefabs.Add(parent.GetChild(i).gameObject);

                ObstacleType type = obstaclePrefabs[i].gameObject.GetComponent<Obstacle>().obstacleType;

                switch (type)
                {
                    case ObstacleType.Car:
                        rnd = 0.05f;
                        break;
                    case ObstacleType.Obstacle:
                        rnd = 0.04f;
                        break;
                    case ObstacleType.GroupObstacle:
                        rnd = 0.02f;
                        break;
                    default:
                        break;
                }
                if (Random.value <rnd)
                {
                    obstaclePrefabs[i].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
