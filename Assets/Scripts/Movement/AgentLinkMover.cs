using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public enum OffMeshLinkMoveMethod
{
    Teleport,
    NormalSpeed,
    Parabola
}

[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof(FootstepSound))]


public class AgentLinkMover : MonoBehaviour
{
    public OffMeshLinkMoveMethod method = OffMeshLinkMoveMethod.Parabola;
    //private Func<FootstepSound> footstep;
    private Func<FSR.FSR_PlayerNeo> footstep;
    [SerializeField] int toggleJumpSound = 3;

    IEnumerator Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //footstep = GetComponent<FootstepSound>;
        footstep = GetComponent<FSR.FSR_PlayerNeo>;
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                if (method == OffMeshLinkMoveMethod.NormalSpeed)
                    yield return StartCoroutine(NormalSpeed(agent));
                else if (method == OffMeshLinkMoveMethod.Parabola)
                    yield return StartCoroutine(Parabola(agent, 2.0f, 0.5f));
                // had to repeat this check because the agent might have been moved meanwhile
                if (agent.isOnOffMeshLink)
                {
                    agent.CompleteOffMeshLink();
                }
                if (footstep != null)
                {
                    toggleJumpSound = (toggleJumpSound == 3 ? 4 : 3);
                    footstep().Step(toggleJumpSound);
                }
            }
            yield return null;
        }
    }

    IEnumerator NormalSpeed(NavMeshAgent agent)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        while (agent.transform.position != endPos)
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 2.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }
}