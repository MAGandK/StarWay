using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour
{
   [SerializeField] private GameObject _bullet;
   [SerializeField] private int _initialSize = 20;
   [SerializeField] private Transform _shootingPoint;
   [SerializeField] private float _spawnInterval = 1.0f;
   
   private List<GameObject> _bulletsPool;
   
   private float _timer;
   
   private void Start()
   {
       PoolBullets();
   }
   private void Update()
   {
       _timer += Time.deltaTime;

       if (Input.GetMouseButtonDown(0) && _timer >= _spawnInterval)
       {
           _timer = 0f;
           SpawnObject();
       }
   }

   private void PoolBullets()
   {
       _bulletsPool = new List<GameObject>();
       for (int i = 0; i < _initialSize; i++)
       {
           GameObject newBullet = Instantiate(_bullet);
           newBullet.SetActive(false);
           _bulletsPool.Add(newBullet);
       }
   }
   
   public GameObject GetPooledObject()
   {
       foreach (var bullet in _bulletsPool)
       {
           if (!bullet.activeInHierarchy)
           {
               return bullet;
           }
       }
       
       GameObject newBullet = Instantiate(_bullet);
       newBullet.SetActive(false);
       _bulletsPool.Add(newBullet);
       return newBullet;
   }
   private void SpawnObject()
   { 
       GameObject bullet = GetPooledObject();
       if (bullet != null)
       {
           bullet.transform.position = _shootingPoint.transform.position;
           bullet.transform.rotation = _shootingPoint.transform.rotation;
           bullet.SetActive(true);
       }
   }
   internal static void ReturnObjectToPool(GameObject bullet)
   {
       bullet.SetActive(false);
   }
}
