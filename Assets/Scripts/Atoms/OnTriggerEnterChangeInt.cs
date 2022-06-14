using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class OnTriggerEnterChangeInt : MonoBehaviour
{
    [SerializeField]
    private IntVariable myVar;
    [SerializeField]
    IntReference valueToAdd;
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
}
