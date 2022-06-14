using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float rotationSpeed = 10f;
    Vector3 targetDirection;
    Vector3 rotationDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        targetDirection = target.position - transform.position;
        // ignore the height of the target
        rotationDirection = targetDirection;
        rotationDirection.y = 0;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, rotationDirection, singleStep, 0.0f);
        // Draw a ray pointing at our target in
        // Debug.DrawRay(transform.position, newDirection, Color.red);
        if (newDirection != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + targetDirection.normalized * moveSpeed * Time.deltaTime);
    }
}
