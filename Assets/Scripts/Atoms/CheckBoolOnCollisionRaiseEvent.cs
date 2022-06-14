using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CheckBoolOnCollisionRaiseEvent : MonoBehaviour
{
    [SerializeField]
    private IntVariable myVar;
    [SerializeField]
    private BoolEvent myEvent;
    [SerializeField]
    private int valueToCompare = 0;

    public void IsLessOrEqual()
    {
        if (myVar.Value <= valueToCompare)
        {
            myEvent.Raise(true);
            print(myVar.name + " is lte " + valueToCompare + ", raising: " + myEvent.name);
        }
    }
    public void IsGreaterOrEqual()
    {
        if (myVar.Value >= valueToCompare)
        {
            myEvent.Raise(true);
            print(myVar.name + " is gte " + valueToCompare + ", raising: " + myEvent.name);
        }
    }
    public void IsEqual()
    {
        if (myVar.Value == valueToCompare)
        {
            myEvent.Raise(true);
            print(myVar.name + " equals " + valueToCompare + ", raising: " + myEvent.name);
        }
    }
}
