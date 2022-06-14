using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformToGameObjects : MonoBehaviour
{
    public List<GameObject> targets;
    public void SetTransform(int i)
    {
        if (i >= 0 && i < targets.Count)
        {
            transform.position = targets[i].transform.position;
            transform.rotation = targets[i].transform.rotation;
            transform.localScale = targets[i].transform.localScale;
        }
    }
}
