using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;


public class ChangeIntWhileCollision : MonoBehaviour
{
    [SerializeField]
    private IntVariable myVar;
    [SerializeField]
    int valueToAdd = 0;
    [SerializeField]
    private bool destroyAfterCollision = true;

    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            myVar.Value += valueToAdd;
            if (destroyAfterCollision)
                Destroy(gameObject);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            myVar.Value -= valueToAdd;
            if (destroyAfterCollision)
                Destroy(gameObject);
        }
    }
}
