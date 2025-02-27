using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg;
    public void TakeDmg()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().CurrentHp -= dmg;
        DestoryThis();
    }

    public void DestoryThis()
    {
        Destroy(gameObject);
    }
}
