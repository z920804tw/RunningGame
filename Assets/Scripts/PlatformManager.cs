using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platformPrefabs;
    public Transform spawnPos;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnNext()
    {
        int rnd = Random.Range(0, platformPrefabs.Length);
        GameObject pf = Instantiate(platformPrefabs[rnd],spawnPos.position, Quaternion.identity);
        pf.transform.SetParent(this.transform);
        pf.name = $"Platform";
    }
}
