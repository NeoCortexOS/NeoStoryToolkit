using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TimerUnityevent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent myEvent;
    [SerializeField]
    private float timeToWait = 0.0f;
    [SerializeField]
    private bool startTimerOnStart = false;

    private void Start()
    {
        if (startTimerOnStart)
        {
            StartTimer();
        }
       // print("TimerUnityevent Start");
    }

  
    public void StartTimer()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToWait);
        myEvent.Invoke();
    }
}
