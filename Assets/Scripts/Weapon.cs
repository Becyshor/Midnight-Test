using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float range = 999f;
    [SerializeField] private float damage = 20f;

    [SerializeField] private Camera shootingCamera;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private StarterAssetsInputs starterAssetsInputs;


    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        ProcessShooting();
    }

    private void ProcessShooting()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (starterAssetsInputs.shoot)
        {
            Transform hitTransform = null;
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                mouseWorldPosition = hit.point;
                hitTransform = hit.transform;
                if (hitTransform != null)
                {
                    EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                    if (target != null)
                    {
                        Debug.Log("Hitt " + hit.transform.name);
                        target.TakeDamage(damage);
                        Instantiate(vfxHitGreen, mouseWorldPosition, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(vfxHitRed, mouseWorldPosition, Quaternion.identity);
                    }
                }
            }
            else return;

            starterAssetsInputs.shoot = false;
        }
    }
}
