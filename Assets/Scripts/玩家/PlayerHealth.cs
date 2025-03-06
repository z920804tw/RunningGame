using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("參數設定")]
    public int maxHp;
    [SerializeField] int currentHp;
    PlayerMovement playerMovement;

    bool isdead;
    public bool IsDead { get { return isdead;}}
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDmg(int dmg)
    {
        currentHp -= dmg;
        if (currentHp <= 0)
        {
            currentHp = 0;
            playerMovement.anim.SetTrigger("Die");
            playerMovement.enabled=false;
            isdead=true;    
            return;
        }

        playerMovement.anim.SetTrigger("Hit");
    }
}
