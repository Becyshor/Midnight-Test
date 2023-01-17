using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 5;
    [SerializeField] private AmmoType ammoType;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType, ammoAmount);
            StartCoroutine(DestroyPickup());
        }
    }

    IEnumerator DestroyPickup()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
