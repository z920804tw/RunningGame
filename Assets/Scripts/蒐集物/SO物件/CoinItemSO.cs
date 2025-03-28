using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Coin", menuName = "Item/Coin_Item")]
public class CoinItemSO : ItemSO
{
    public override void CollectEffect()
    {
        //增加金幣數量  
        GameStatusUI gameStatusUI = GameObject.FindWithTag("GameManager").GetComponent<GameStatusUI>();
        if (gameStatusUI != null)
        {
            gameStatusUI.UpdateCoin();
        }
    }
}
