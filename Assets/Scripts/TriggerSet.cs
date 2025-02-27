using UnityEngine;
using UnityEngine.Events;

public class TriggerSet : MonoBehaviour
{
    public UnityEvent triggerEvent;
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerEvent.Invoke();
        }
    }
}
