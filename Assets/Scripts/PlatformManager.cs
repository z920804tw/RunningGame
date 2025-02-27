using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platformPrefabs;

    [SerializeField] GameObject preObj;
    [SerializeField] Vector3 spawnPos;
    [SerializeField] float destoryTime;
    void Start()
    {
        preObj = gameObject.transform.GetChild(0).gameObject;
        // preObj.GetComponentInChildren<TriggerSet>().triggerEvent.AddListener(SpawnNext);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnNext()
    {

        if (preObj != null)
        {
            Destroy(preObj, destoryTime);
        }
        GameObject pf = Instantiate(platformPrefabs[0], preObj.transform.position + spawnPos, Quaternion.identity);
        pf.transform.SetParent(this.transform);
        pf.name = $"Platform";

        preObj = pf;
    }
}
