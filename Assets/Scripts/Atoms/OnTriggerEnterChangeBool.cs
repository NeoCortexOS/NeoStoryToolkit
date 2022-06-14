using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class OnTriggerEnterChangeBool : MonoBehaviour
{
    [SerializeField]
    private BoolVariable myVar;
    [SerializeField]
    bool valueToSet = true;
    [SerializeField]
    private bool destroyAfterCollision = true;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            myVar.Value = valueToSet;
            if (destroyAfterCollision)
                Destroy(gameObject);
        }
    }
}
