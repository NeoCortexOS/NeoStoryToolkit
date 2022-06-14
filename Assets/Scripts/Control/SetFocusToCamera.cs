using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetFocusToCamera : MonoBehaviour
{
    //public GameObject Camera;
    public CinemachineVirtualCamera Camera;
    public bool ChangeBackAfterDelay;
    public bool ChangeBackOnExit;
    public float DelayToChangeBack;
    private int HighestPriority = 500;


    // Start is called before the first frame update
    void Start()
    {
        Camera.Priority = 0;
    }

    public void SwitchCam()
    {
        Camera.Priority = HighestPriority;
        HighestPriority = HighestPriority + 1;

        if (ChangeBackAfterDelay)
        {
            StartCoroutine(GoBackToCamera());
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            SwitchCam();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player" && ChangeBackOnExit)
        {
            StartCoroutine(GoBackToCamera());
        }
    }


    IEnumerator GoBackToCamera()
    {
        yield return new WaitForSeconds(DelayToChangeBack);
        Camera.Priority = 0;
    }
}