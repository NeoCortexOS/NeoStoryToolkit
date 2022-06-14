using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class OnTriggerChangeBoolOnOff : MonoBehaviour
{
    [SerializeField]
    private BoolVariable myVar;
    [SerializeField]
    private bool destroyAfterExit = false;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            myVar.Value = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            myVar.Value = false;
            if (destroyAfterExit)
                Destroy(gameObject);
        }
    }
}
