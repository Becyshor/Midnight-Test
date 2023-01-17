using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private AudioSource zombieSound;

    private NavMeshAgent navMeshAgent;
    private EnemyHealth health;
    private CapsuleCollider capsuleCollider;
    private Animator animator;
    private Transform target;

    private float targetDistance = Mathf.Infinity;
    private float turnSpeed = 5f;
    private bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
            StopZombieSound();
            return;
        }

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

    private void OnDamageTaken()
    {
        isProvoked = true;
        PlayZombieSound();
    }

    private void EngageTarget()
    {
        FaceTarget();
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
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        animator.SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void PlayZombieSound()
    {
        zombieSound.Play();
    }
    
    public void StopZombieSound()
    {
        zombieSound.Stop();
    }
}
