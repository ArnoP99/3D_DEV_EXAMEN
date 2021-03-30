using UnityEngine;
using UnityEngine.AI;

public class enemyfollow : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform Player;

    void Update()
    {
        enemy.SetDestination(Player.position);
    }
}