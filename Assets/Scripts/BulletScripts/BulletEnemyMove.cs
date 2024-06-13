using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyMove : MonoBehaviour
{
    [SerializeField] private float _bulletEnemySpeed;

    private Rigidbody _rbBullletEmemy;

    private void Start()
    {
       _rbBullletEmemy = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rbBullletEmemy.velocity = -transform.forward * _bulletEnemySpeed;
    }
}
