using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public Platform platform;
    void Start()
    {
        transform.root.TryGetComponent<Platform>(out platform);



    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            platform.SpawnNext();
        }
    }
}
