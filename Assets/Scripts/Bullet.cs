using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    [SerializeField] private float speed = 50f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rigid.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            //hit target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else
        {
            //hit else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
