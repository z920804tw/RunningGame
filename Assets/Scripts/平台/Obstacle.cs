using UnityEditor;
using UnityEngine;

public enum ObstacleType
{
    None,
    Car,
    Obstacle,
}
public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public ObstacleType obstacleType;

}
