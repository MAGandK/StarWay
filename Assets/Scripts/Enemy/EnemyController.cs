using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEnemy;

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
            Instantiate(_explosionEnemy, transform.position, transform.rotation);
        }

        if (other.tag != "BulletEnemy")
        {
            OnEnemyDestroyed?.Invoke();
            GameObject newExplosion = Instantiate(_explosionEnemy, other.transform.position, other.transform.rotation);
            EnemySpawner.ReturnEnemyToPool(gameObject);
            Destroy(newExplosion);
            Destroy(other.gameObject);
        }
    }
}
   

