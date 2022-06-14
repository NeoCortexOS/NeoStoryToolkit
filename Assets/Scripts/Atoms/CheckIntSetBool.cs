using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CheckIntSetBool : MonoBehaviour
{
    [SerializeField]
    private BoolVariable myBool;
    [SerializeField]
    private IntReference valueToCompare;

    public void IsLessOrEqual(int myVar)
    {
        if (myVar <= valueToCompare.Value)
        {
            print(myVar + " is less or equals " + valueToCompare.Value);
            if (myBool.Value == false)
            {
                myBool.SetValue(true);
                print(" setting " + myBool.name + " true");
            };
        }
    }
    public void IsGreaterOrEqual(int myVar)
    {
        if (myVar >= valueToCompare.Value)
        {
            print(myVar + " is greater or equals " + valueToCompare.Value);
            if (myBool.Value == false)
            {
                myBool.SetValue(true);
                print(" setting " + myBool.name + " true");
            };
        }
    }
    public void IsEqual(int myVar)
    {
        if (myVar == valueToCompare.Value)
        {
            print(myVar + " equals " + valueToCompare.Value);
            if (myBool.Value == false)
            {
                myBool.SetValue(true);
                print(" setting " + myBool.name +" true");
            }
        }
    }
}
