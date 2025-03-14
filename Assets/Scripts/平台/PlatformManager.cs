using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlatformManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platformPrefabs;
    public float platformLength;
    [SerializeField] GameObject preObj;
    public float platformSpeed = 8;

    [Header("障礙物")]
    public GameObject[] obstaclePrefabs;
    void Start()
    {
        preObj = transform.GetChild(0).gameObject;
        preObj.GetComponent<Platform>().MoveSpeed = platformSpeed;

    }
    public void SpawnNext()
    {
        //取得下一個平台生成位置
        Vector3 spawnPos = new Vector3(preObj.transform.position.x, preObj.transform.position.y,
            preObj.transform.position.z + platformLength);
        spawnPos.z = (int)spawnPos.z;

        //隨機取哪個平台
        int rnd = Random.Range(0, platformPrefabs.Length);
        GameObject pf = Instantiate(platformPrefabs[rnd], spawnPos, Quaternion.identity);
        pf.transform.SetParent(this.transform);
        pf.name = $"Platform";
        pf.GetComponent<Platform>().MoveSpeed = platformSpeed;

        preObj = pf;
    }

    public void AddPlatformSpeed(int increaseSpeed)
    {
        platformSpeed += increaseSpeed; //平台管理器的平台速度增加
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        if (platforms != null)
        {
            foreach (GameObject i in platforms) //替場上所有的平台加速
            {   
               i.GetComponent<Platform>().MoveSpeed+=increaseSpeed; 
            }
        }   
    }
}
