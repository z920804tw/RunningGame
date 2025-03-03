using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg;
    public void TakeDmg()
    {
        PlayerHealth playerHealth =GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.TakeDmg(dmg);
        DestoryThis();
    }

    void DestoryThis()
    {
        Destroy(gameObject);
    }
}
