using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InvincibleStar", menuName = "Item/InvincibleStar_Item")]
public class InvincibleStarItemSO : ItemSO
{
    public float invincibleTime;
    public override void CollectEffect()
    {
        PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

        playerHealth.SetInvincible(invincibleTime);
    }
}
