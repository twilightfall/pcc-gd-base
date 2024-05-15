using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMoveController : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    private List<Transform> waypoints;

    int destinationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f) MoveToNext();
    }

    private void MoveToNext()
    {
        if(waypoints.Count == 0)
        {
            return;
        }

        agent.destination = waypoints[destinationIndex].position;

        destinationIndex = (destinationIndex + 1) % waypoints.Count;
    }
}
