using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class OnTriggerEnterRaiseEvent : MonoBehaviour
{
    [SerializeField]
    private VoidEvent myEvent;
   
    [SerializeField]
    private bool destroyAfterCollision = true;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            myEvent.Raise();
            if (destroyAfterCollision)
                Destroy(gameObject);
        }
    }
}
