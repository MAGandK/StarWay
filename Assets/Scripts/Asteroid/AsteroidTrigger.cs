using System;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    public delegate void AsteroidDestroyed();
    public static event AsteroidDestroyed OnAsteroidDestroyed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Debug.Log("Сталкнулся с Boundary");
            return;
        }
        if (_explosion != null)
        {
            Instantiate(_explosion, transform.position, transform.rotation);
        }
        
        if (other.tag == "Bullet")
        {
            OnAsteroidDestroyed?.Invoke();
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, other.transform.rotation);
            SpawnAsteroids.ReturnAsteroidToPool(gameObject);
            PlayerShoots.ReturnObjectToPool(other.gameObject);
            Debug.Log("Сталкнулся с Bullet");
        }
        else if (other.tag == "Player")
        {
            OnAsteroidDestroyed?.Invoke();
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, other.transform.rotation);
            PlayerController.Instanse.TakedDamage();
            SpawnAsteroids.ReturnAsteroidToPool(gameObject);
            Debug.Log("Сталкнулся с Player");
        }
        else if (other.tag == "Enemy")
        {
            OnAsteroidDestroyed?.Invoke();
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, other.transform.rotation);
            SpawnAsteroids.ReturnAsteroidToPool(gameObject);
            EnemySpawner.ReturnEnemyToPool(gameObject);
            Debug.Log("Сталкнулся с Enemy");
        }
    }
}
