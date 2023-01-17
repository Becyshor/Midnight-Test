using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;

    private Score score;

    private bool isDead;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("dead");
        score.IncreasePlayerKills();
    }
}
