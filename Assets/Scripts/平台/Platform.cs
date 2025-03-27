using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("平台設定")]

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public bool isStop;
    Rigidbody rb;
    PlatformManager platformManager;
    GameManager gameManager;

    [Header("平台障礙物設定")]
    public Transform parent;
    public bool randomClose;
    public bool randomSpawn;
    [SerializeField] List<GameObject> obstaclePrefabs;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        platformManager = transform.root.GetComponent<PlatformManager>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        for (int i = 0; i < parent.childCount; i++)
        {
            obstaclePrefabs.Add(parent.GetChild(i).gameObject);
        }

        ObstacleSpawner();
        ObstacleClose();
    }

    // Update is called once per frame
    void Update()
    {

        if (isStop || gameManager.gameStatusType == GameStatusType.End) return;
        transform.position += transform.forward * -moveSpeed * Time.deltaTime;


        if (transform.position.z <= -100)
        {
            Destroy(gameObject);
        }
    }
    void ObstacleSpawner()
    {
        if (randomSpawn)
        {
            float count = obstaclePrefabs.Count;
            for (int i = 0; i < count; i++)
            {
                int rnd = Random.Range(0, platformManager.obstaclePrefabs.Length);
                GameObject obstacle = Instantiate(platformManager.obstaclePrefabs[rnd],
                obstaclePrefabs[i].transform.position, Quaternion.identity);
                obstacle.transform.SetParent(obstaclePrefabs[i].transform);
                Debug.Log("生成");
            }
        }
    }
    void ObstacleClose()
    {
        if (randomClose) //隨機開關
        {
            float count = obstaclePrefabs.Count;
            float rnd = 0f;
            for (int i = 0; i < count; i++) //新增物件
            {

                if (obstaclePrefabs[i].gameObject.GetComponentInChildren<Obstacle>()==null) continue;
                ObstacleType type = obstaclePrefabs[i].gameObject.GetComponentInChildren<Obstacle>().obstacleType;

                switch (type)
                {
                    case ObstacleType.Car:
                        rnd = 0.05f;
                        break;
                    case ObstacleType.Obstacle:
                        rnd = 0.04f;
                        break;
                    default:
                        rnd = -999;
                        break;
                }
                if (rnd > Random.value)
                {
                    obstaclePrefabs[i].SetActive(false);
                    Debug.Log("關閉");
                }
            }
        }
    }
}
