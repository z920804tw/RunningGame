using UnityEditor;
using UnityEngine;

public enum ObstacleType
{
    None,
    Car,
    Obstacle,
    GroupObstacle,
}
public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public ObstacleType obstacleType;
    public int dmg;
    public GameObject destoryEffect;
    public bool canDestory;
    void DestoryThis()
    {
        GameObject effect = Instantiate(destoryEffect,transform.position,Quaternion.identity);
        effect.transform.SetParent(transform.parent);
        Destroy(effect,2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDmg(dmg);
            if (canDestory) DestoryThis();
        }
    }
}
