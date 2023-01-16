using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float range = 999f;
    [SerializeField] private float damage = 20f;

    [SerializeField] private Camera shootingCamera;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private ParticleSystem vfxGun;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private AmmoType ammoType;

    private StarterAssetsInputs starterAssetsInputs;


    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (starterAssetsInputs.shoot)
            Shoot();
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayGunEffect();
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount(ammoType);
        }
    }

    private void PlayGunEffect()
    {
        vfxGun.Play();
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
                        Instantiate(vfxHitRed, hit.point, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(vfxHitGreen, hit.point, Quaternion.identity);
                    }
                }
            }
            else return;

            starterAssetsInputs.shoot = false;
        //}
    }

}
