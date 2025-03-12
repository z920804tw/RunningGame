using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("平台設定")]
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public bool isStop;
    Rigidbody rb;

    [Header("平台障礙物設定")]
    public Transform parent;
    public bool isRandom;
    [SerializeField] List<GameObject> obstaclePrefabs;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ObstacleSpawner();
    }

    // Update is called once per frame
    void Update()
    {

        if (isStop) return;
        transform.position += transform.forward * -moveSpeed * Time.deltaTime;


        if (transform.position.z <= -100)
        {
            Destroy(gameObject);
        }
    }

    void ObstacleSpawner()
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
                if (Random.value < rnd)
                {
                    obstaclePrefabs[i].SetActive(false);
                }
            }
        }
    }
}
