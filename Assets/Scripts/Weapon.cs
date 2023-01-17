using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float range = 999f;
    [SerializeField] private float damage = 20f;

    [SerializeField] private Camera shootingCamera;
    [SerializeField] private Transform vfxHitOther;
    [SerializeField] private Transform vfxHitTarget;
    [SerializeField] private ParticleSystem vfxGun;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private TextMeshProUGUI ammoText;

    private AudioSource shotSound;
    private StarterAssetsInputs starterAssetsInputs;


    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        shotSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        DisplayAmmo();
        if (starterAssetsInputs.aim && starterAssetsInputs.shoot)
            Shoot();
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = "Ammo: " + currentAmmo.ToString();
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayGunEffect();
            PlayGunSound();
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount(ammoType);
        }
    }

    private void PlayGunEffect()
    {
        vfxGun.Play();
    }

    private void PlayGunSound()
    {
        shotSound.Play();
    }

    private void ProcessRaycast()
    {
        Vector2 screenCenterPoint = new(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        //if (starterAssetsInputs.shoot)
        //{
            Transform hitTransform = null;
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                hitTransform = hit.transform;
                if (hitTransform != null)
                {
                    EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                    if (target != null)
                    {
                        Debug.Log("Hitt " + hit.transform.name);
                        target.TakeDamage(damage);
                        Instantiate(vfxHitTarget, hit.point, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(vfxHitOther, hit.point, Quaternion.identity);
                    }
                }
            }
            else return;

            starterAssetsInputs.shoot = false;
        //}
    }

}
