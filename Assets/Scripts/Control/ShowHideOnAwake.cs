using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideOnAwake : MonoBehaviour
{
    [SerializeField] MeshRenderer[] toShow;
    [SerializeField] MeshRenderer[] toHide;
    void Awake()
    {
        foreach (MeshRenderer item in toShow)
        {
            item.enabled = true;
        }
        foreach (MeshRenderer item in toHide)
        {
            item.enabled = false;
        }
    }
}
