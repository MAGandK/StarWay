using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEnemy;
    [SerializeField] private float explosionLifetime = 2.0f;

    public delegate void EnemyDestroyed();
    public static event EnemyDestroyed OnEnemyDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "BulletEnemy")
        {
            return;
        }

        if (_explosionEnemy != null)
        {
            GameObject newExplosion = Instantiate(_explosionEnemy, transform.position, transform.rotation);
            Destroy(newExplosion, explosionLifetime);
        }

        if (other.tag != "BulletEnemy")
        {
            OnEnemyDestroyed?.Invoke();
            EnemySpawner.ReturnEnemyToPool(gameObject);
            Destroy(other.gameObject);
        }
    }
}
   

