using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100;
    [SerializeField] private Healthbar healthbar;

    private DamageDisplay damageDisplay;

    private void Start()
    {
        damageDisplay = GetComponent<DamageDisplay>();
        healthbar.UpdateHealthbar(100, hitPoints);
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        healthbar.UpdateHealthbar(100, hitPoints);
        damageDisplay.ShowDamageDisplay();

        if (hitPoints <= 0)
        {
            healthbar.UpdateHealthbar(100, hitPoints);
            BroadcastMessage("HandleDeath");
        }
    }
}
