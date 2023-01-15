using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            GetComponent<Animator>().SetTrigger("dead");
            GetComponent<NavMeshAgent>().speed = 0f;
            StartCoroutine(DeathCoroutine());
            //Destroy(gameObject);
        }

        IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
