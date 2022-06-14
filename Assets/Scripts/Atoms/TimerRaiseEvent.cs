using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class TimerRaiseEvent : MonoBehaviour
{
    [SerializeField]
    private VoidEvent myEvent;
    [SerializeField]
    private int timeToWait = 0;

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToWait);
        myEvent.Raise();
    }
}
