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
    public bool canDestory;
    void DestoryThis()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDmg(dmg);
            Debug.Log(dmg);
            if (canDestory) DestoryThis();
        }
    }
}
