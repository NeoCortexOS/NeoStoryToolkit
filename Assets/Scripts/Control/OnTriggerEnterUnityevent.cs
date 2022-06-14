using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterUnityevent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent myEvent;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            myEvent.Invoke();
        }
    }
}
