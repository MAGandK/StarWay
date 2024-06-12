using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEnemy;
    
    public delegate void EnemyDestroyed();
    public static event EnemyDestroyed OnEnemyDestroyed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (_explosionEnemy != null)
        {
            Instantiate(_explosionEnemy, transform.position, transform.rotation);
        }
        
        if (other.tag == "Bullet")
        {
            OnEnemyDestroyed?.Invoke();
            Instantiate(_explosionEnemy, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            EnemySpawner.ReturnEnemyToPool(gameObject);
            PlayerShoots.ReturnObjectToPool(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            OnEnemyDestroyed?.Invoke();
            Instantiate(_explosionEnemy, other.transform.position, other.transform.rotation);
            EnemySpawner.ReturnEnemyToPool(gameObject);
            PlayerController.OnDiedPlayer();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Asteroid")
        {
            Instantiate(_explosionEnemy, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            EnemySpawner.ReturnEnemyToPool(gameObject);
        }
    }
}
