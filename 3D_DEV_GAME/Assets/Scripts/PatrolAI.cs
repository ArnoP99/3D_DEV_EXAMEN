using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public float FollowDistance;
    public NavMeshAgent patroler;
    public Transform Player;
    public Transform[] points;
    public Collider box;

    private int destPoint = 0;
    private NavMeshAgent agent;
    private int currentControlPointIndex = 0;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;

        GotoNextPoint();
    }


 


    void Update()
    {

        if (agent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);

            bool patrol = false;
            bool follow = (dist < FollowDistance);


            if (follow)
            {
                agent.SetDestination(Player.transform.position);
            }

            patrol = !follow && points.Length > 0;


            if (patrol)
            {
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();

            }

        }




    }


    void GotoNextPoint()
    {


        if (points.Length > 0)
        {
            agent.destination = points[currentControlPointIndex].position;

            currentControlPointIndex++;
            currentControlPointIndex %= points.Length;
        }

    }


}
