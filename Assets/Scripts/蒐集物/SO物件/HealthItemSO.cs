using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Health", menuName = "Item/Health_Item")]
public class HealthItemSO : ItemSO
{
    public int addHp;
    public override void CollectEffect()
    {
        PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        GameStatusUI gameStatusUI = GameObject.FindWithTag("GameManager").GetComponent<GameStatusUI>();
        if (playerHealth != null &&playerHealth.CurrentHp<playerHealth.maxHp)
        {
            playerHealth.CurrentHp += addHp;
            gameStatusUI.IncreaseHpUI(addHp);
        }
    }

}
