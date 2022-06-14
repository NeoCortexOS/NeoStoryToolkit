
using UnityEngine;
using UnityEngine.AI;

public class ControllerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;

    [SerializeField] float _maxDistance = 3f;
    [SerializeField] float _maxDrop = 3f;

    void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();
    
    void Update()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3? point = GetDestination(input.normalized);
        if (point.HasValue)
            _navMeshAgent.SetDestination(point.Value);
    }

    Vector3? GetDestination(Vector3 direction)
    {
        for (float height = -_maxDrop; height < 1; height += 0.1f)
        {
            var destination = GetDestination(direction, height);
            if (destination.HasValue)
                return destination.Value;
        }
        return null;
    }

    Vector3? GetDestination(Vector3 direction, float height)
    {
        for (float distance = 1f; distance < _maxDistance; distance += 0.1f)
        {
            Vector3 offset = direction * distance + (Vector3.up * height);
            var destination = CheckForNavMeshAtOffset(offset);
            if (destination.HasValue)
                return destination;
        }
        return null;
    }

    Vector3? CheckForNavMeshAtOffset(Vector3 offset)
    {
        var targetPoint = transform.position + offset;

        if (NavMesh.SamplePosition(targetPoint, out var hitInfo, 0.1f, NavMesh.AllAreas))
        {
            Debug.DrawLine(targetPoint, targetPoint + Vector3.up * 0.05f, Color.green);
            return hitInfo.position;
        }
        else
        {
            Debug.DrawLine(targetPoint, targetPoint + Vector3.up * 0.05f, Color.yellow);
            return null;
        }
    }
}
