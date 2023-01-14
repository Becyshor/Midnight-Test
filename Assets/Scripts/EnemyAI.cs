using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;

    private NavMeshAgent navMeshAgent;

    private float targetDistance = Mathf.Infinity;
    private bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (targetDistance <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (targetDistance > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (targetDistance <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log(name + "Attacks");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
