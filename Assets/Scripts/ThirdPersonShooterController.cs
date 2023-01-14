using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private LayerMask aimColliderLayerMask = new();

    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

    //[SerializeField] private Transform bulletPrefab;
    //[SerializeField] private Transform spawnBulletPosition;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        
        Vector2 screenCenterPoint = new(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        Transform hitTransform = null;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }
        else
        {
            return;
        }

        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }

        /*if (starterAssetsInputs.shoot)
        {
            if (hitTransform != null)
            {
                EnemyHealth target = hitTransform.GetComponent<EnemyHealth>();

                if (target != null)
                {
                    
                    target.TakeDamage(weaponDamage);
                    Instantiate(vfxHitGreen, mouseWorldPosition, Quaternion.identity);
                }
                else
                {
                    //hit else
                    Instantiate(vfxHitRed, mouseWorldPosition, Quaternion.identity);
                }
            }
            //Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            //Instantiate(bulletPrefab, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }*/
    }
}
