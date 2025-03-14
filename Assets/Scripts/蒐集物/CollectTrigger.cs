using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public ItemSO itemSO;

    public AudioClip collectClip;
    AudioSource audioSource;
    [SerializeField] bool canMoveTo;

    GameObject target;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveTo)
        {
            Vector3 moveDir = target.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);
            Debug.DrawRay(transform.position, moveDir.normalized*2, Color.red);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            anim.SetTrigger("Collect");
            itemSO.CollectEffect();

            audioSource.PlayOneShot(collectClip);

            //移動到玩家位置
            canMoveTo = true;
            target = other.gameObject;

            GetComponent<BoxCollider>().enabled = false; //觸發一次後就關掉碰撞相
            Destroy(gameObject, 3f);
        }
    }
}
