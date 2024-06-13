using System;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;

    public delegate void AsteroidDestroyed();
    public static event AsteroidDestroyed OnAsteroidDestroyed;

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

        if (other.tag == "Bullet" || other.tag == "Enemy")
        {
            DieAsteroid();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            DieAsteroid();
            PlayerController.Instanse.TakedDamage();
        }
        
        SpawnAsteroids.ReturnAsteroidToPool(gameObject);
    }
    private void DieAsteroid()
    {
        OnAsteroidDestroyed?.Invoke();
        Destroy(gameObject);
    }
}

