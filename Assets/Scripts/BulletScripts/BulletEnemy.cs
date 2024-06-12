using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float _bulletEnemySpeed;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _bulletEnemySpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player")
        {
            PlayerController.OnDiedPlayer();
            Destroy(other.gameObject);
            Debug.Log(" BulletEnemy Сталкнулся с Player");
        }
        else if (other.tag == "Asteroid")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log(" BulletEnemy Сталкнулся с Asteroid ENEMY");
        }
        else if (other.tag == "Bullet") 
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("BulletEnemy Сталкнулся с пулей игрока");
        }
    }
}
