using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 20;
    private PlayerHealth targetHealth;

    private void Start()
    {
        targetHealth = FindObjectOfType<PlayerHealth>();
    }

    private void AttackHitEvent()
    {
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
            Debug.Log("Baang!!!");
        }
    }
}
