using System;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    public delegate void AsteroidDestroyed();
    public static event AsteroidDestroyed OnAsteroidDestroyed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            OnAsteroidDestroyed?.Invoke();
            
            SpawnAsteroids.ReturnAsteroidToPool(gameObject);
            PlayerShoots.ReturnObjectToPool(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
           PlayerController.Instanse.TakedDamage();
           Debug.Log("Сталкновение");
        }
    }
}
