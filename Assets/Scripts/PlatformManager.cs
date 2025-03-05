using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platformPrefabs;

    [SerializeField] GameObject preObj;
    [SerializeField] float destoryTime;
    void Start()
    {
        preObj = gameObject.transform.GetChild(0).gameObject;
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
        int rnd = Random.Range(0, platformPrefabs.Length);
        GameObject pf = Instantiate(platformPrefabs[rnd], preObj.transform.position + new Vector3(transform.position.x, transform.position.y, 100), Quaternion.identity);
        pf.transform.SetParent(this.transform);
        pf.name = $"Platform";

        preObj = pf;
    }
}
