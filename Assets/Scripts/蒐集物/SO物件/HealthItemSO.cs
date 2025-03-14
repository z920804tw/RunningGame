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
        if (playerHealth != null)
        {
            playerHealth.CurrentHp += addHp;
            Debug.Log("add");
        }
    }

}
