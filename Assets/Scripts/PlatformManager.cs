using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platformPrefabs;
    public float platformLength;
    [SerializeField] GameObject preObj;
    
    void Start()
    {
        preObj=transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    
    public void SpawnNext()
    {
        Vector3 spawnPos=new Vector3(preObj.transform.position.x,preObj.transform.position.y,
            preObj.transform.position.z+platformLength);

        spawnPos.z=(int)spawnPos.z;
        Debug.Log(spawnPos);
        int rnd = Random.Range(0, platformPrefabs.Length);
        GameObject pf = Instantiate(platformPrefabs[rnd],spawnPos, Quaternion.identity);
        pf.transform.SetParent(this.transform);
        pf.name = $"Platform";
        
        preObj=pf;
    }
}
