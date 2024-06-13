using System;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;

    public delegate void AsteroidDestroyed();
    public static event AsteroidDestroyed OnAsteroidDestroyed;
    
    public delegate void AsteroidDieByPlayer();
    public static event AsteroidDieByPlayer OnDieByPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (_explosion != null)
        {
            Instantiate(_explosion, transform.position, transform.rotation);
        }

        if (other.tag == "BulletEnemy" || other.tag == "Enemy")
        {
            DieAsteroid();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player" || other.tag == "Bullet")
        {
            OnDieByPlayer?.Invoke();
            PlayerController.Instanse.TakedDamage();
            DieAsteroid();
        }
        
        SpawnAsteroids.ReturnAsteroidToPool(gameObject);
    }
    private void DieAsteroid()
    {
        OnAsteroidDestroyed?.Invoke();
        Destroy(gameObject);
    }
}

