using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    Rigidbody rb;
    PlayerHealth playerHealth;
    bool isStop;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isStop) return;
        isStop = playerHealth.IsDead;
        transform.position += transform.forward * -moveSpeed * Time.deltaTime;


        if (transform.position.z <= -100)
        {
            Destroy(gameObject);
        }
    }
}
