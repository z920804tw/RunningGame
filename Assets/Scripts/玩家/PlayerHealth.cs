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
        GameObject.FindWithTag("GameManager").GetComponent<GameStatusUI>().IncreaseHpUI(maxHp);
    }


    public void TakeDmg(GameObject hit, int dmg)
    {
        if (invincible && hit.GetComponent<BorderTrigger>().canDestory) return;

        currentHp -= dmg;
        //UI更新
        GameObject.FindWithTag("GameManager").GetComponent<GameStatusUI>().DecreaseHpUI(dmg);
        if (currentHp <= 0)
        {
            currentHp = 0;
            playerMovement.anim.SetTrigger("Die");
            playerMovement.enabled = false;
            isdead = true;

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().EndGame(); //設定遊戲狀態為結束
            return;
        }
        playerMovement.anim.SetTrigger("Hit");
    }


    public void SetInvincible(float timer) //開始無敵
    {
        invincible = true;
        StartCoroutine(InvincibleReset(timer));
    }

    IEnumerator InvincibleReset(float timer) //重製無敵
    {
        yield return new WaitForSeconds(timer);
        invincible = false;
    }
}
