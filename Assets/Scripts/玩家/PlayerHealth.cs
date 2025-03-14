using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("參數設定")]
    public int maxHp;
    [SerializeField] int currentHp;
    public int CurrentHp { get { return currentHp; } set { currentHp = value; } }
    PlayerMovement playerMovement;

    public bool invincible = false;

    bool isdead;
    public bool IsDead { get { return isdead; } }
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDmg(GameObject hit,int dmg)
    {
        if (invincible && hit.GetComponent<Obstacle>().canDestory==true) return;

        currentHp -= dmg;
        if (currentHp <= 0)
        {
            currentHp = 0;
            playerMovement.anim.SetTrigger("Die");
            playerMovement.enabled = false;
            isdead = true;

            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject i in platforms)
            {
                i.GetComponent<Platform>().isStop = true;
            }
            return;
        }

        playerMovement.anim.SetTrigger("Hit");
    }


    public void SetInvincible(float timer)
    {
        invincible = true;
        StartCoroutine(InvincibleReset(timer));
    }

    IEnumerator InvincibleReset(float timer)
    {
        yield return new WaitForSeconds(timer);
        invincible=false;
    }
}
