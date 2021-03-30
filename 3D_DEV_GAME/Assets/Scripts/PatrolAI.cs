using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PatrolAI : MonoBehaviour
{
    public float FollowDistance;
    public NavMeshAgent patroler;
    public Transform Player;
    public Transform[] points;
    public Collider box;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
            agent.destination = points[Random.Range(0, 43)].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("gameover");
            SceneManager.LoadScene("MainScene");
        }
    }
}


