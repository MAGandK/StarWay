using System;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float explosionLifetime = 2.0f;

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
            GameObject newExplosion = Instantiate(_explosion, transform.position, transform.rotation);
            Destroy( newExplosion, explosionLifetime);
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

