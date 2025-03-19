using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTrigger : MonoBehaviour
{
    public int dmg;
    public GameObject destoryEffect;
    [Header("音效")]
    public AudioSource audioSource;
    public AudioClip hitClip;
    [Header("Debug")]
    public bool canDestory;

    void DestoryThis()
    {
        GameObject effect = Instantiate(destoryEffect, transform.position, Quaternion.identity);
        effect.transform.SetParent(transform.parent);
        Destroy(effect, 1.2f);
        Destroy(gameObject, 0.5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(hitClip);
            other.GetComponent<PlayerHealth>().TakeDmg(gameObject, dmg);
            if (canDestory) DestoryThis();
        }
    }
}
