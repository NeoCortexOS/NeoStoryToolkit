using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class onCollisionBadTile : MonoBehaviour
{
    private NavMeshObstacle navMeshObstacle;
    [SerializeField]
    private TMP_Text myText;
    void Start()
    {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            navMeshObstacle.enabled = true;
            myText.enabled = false;
           //if (destroyAfterExit)
             //   Destroy(gameObject);
        }
    }
}
