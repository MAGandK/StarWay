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
}
