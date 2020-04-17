using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{

    public Transform target;
    public Transform[] points;
    private int destPoint = 0;
    NavMeshAgent agent;
    bool ascending = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        if(destPoint < points.Length - 1 && ascending)
        {
            destPoint = (destPoint + 1);
        }  
        else
        {
            ascending = false;
            destPoint = (destPoint - 1);
        }

        if (destPoint == 0)
            ascending = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 1.5f)
            GotoNextPoint();

        //agent.SetDestination(target.position);
    }
}
