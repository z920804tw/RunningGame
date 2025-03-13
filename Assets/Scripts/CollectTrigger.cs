using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Collect");
            transform.SetParent(null);
            Destroy(gameObject,1.2f);
            Debug.Log("+1");
        }
    }
}
