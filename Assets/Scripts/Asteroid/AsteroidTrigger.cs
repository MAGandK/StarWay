using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    public delegate void AsteroidDestroyed();
    public static event AsteroidDestroyed OnAsteroidDestroyed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            SpawnAsteroids.ReturnAsteroidToPool(gameObject);
            Debug.Log("Астероид УНИЧТОЖЕН");
            OnAsteroidDestroyed?.Invoke();
        }
    }
}
