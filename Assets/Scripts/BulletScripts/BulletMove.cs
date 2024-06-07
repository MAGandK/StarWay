using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private int _speedBullet;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speedBullet;
    }
    private void OnEnable()
    {
        AsteroidTrigger.OnAsteroidDestroyed += AsteroidDestroyed;
    }

    private void AsteroidDestroyed()
    {
        PlayerShoots.ReturnObjectToPool(gameObject);
        Debug.Log("Пуля в стопку");
    }
    
    private void OnDisable()
    {
        AsteroidTrigger.OnAsteroidDestroyed -= AsteroidDestroyed;
    }
}