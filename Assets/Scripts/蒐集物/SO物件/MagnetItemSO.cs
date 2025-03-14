using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Magnet", menuName = "Item/Magnet_Item")]
public class MagnetItemSO : ItemSO
{
    public Vector3 colliderSize;
    public float collectTime;
    public override void CollectEffect()
    {

        //修改蒐集碰撞相變成長方形
        PlayerMovement playerMovement =GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playerMovement.ChangeCollectSize(collectTime,colliderSize);
    }
}
