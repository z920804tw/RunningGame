using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformPrefab;
    public Transform spawnPos;
    public float destoryTime;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SpawnNext()
    {
        GameObject pf = Instantiate(platformPrefab, spawnPos.position, Quaternion.identity);
        pf.name=$"Platform";
        Destroy(this.gameObject,destoryTime);
    }
}
