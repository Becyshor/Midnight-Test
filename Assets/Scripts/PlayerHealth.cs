using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;

    private DamageDisplay damageDisplay;

    private void Start()
    {
        damageDisplay = GetComponent<DamageDisplay>();
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;

        damageDisplay.ShowDamageDisplay();

        if (hitPoints <= 0)
        {
            BroadcastMessage("HandleDeath");
        }
    }
}
