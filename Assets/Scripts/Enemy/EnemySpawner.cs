using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefabs;
    [SerializeField] private Transform _spawnEnemy;
    [SerializeField] private int _initialSize;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Boundary _boundary;
    private List<GameObject> _enemies;
    private float _timer;
    
    private void Start()
    {
        _enemies = new List<GameObject>();

        for (int i = 0; i < _initialSize; i++)
        {
            GameObject newEnemy = Instantiate(_enemyPrefabs, _spawnEnemy.position, _spawnEnemy.rotation);
            newEnemy.SetActive(false);
            _enemies.Add(newEnemy);
        }
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            SpawnEnemies();
        }
    }
    
    internal GameObject GetPoolEnemy()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null && !enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        GameObject newEnemy  = Instantiate(_enemyPrefabs, _spawnEnemy.position, _spawnEnemy.rotation);
        newEnemy.SetActive(false);
        _enemies.Add(newEnemy);
        return newEnemy ;
    }
    private void SpawnEnemies()
    {
        GameObject enemy = GetPoolEnemy();

        if (enemy != null)
        {
            enemy.transform.position = new Vector3
            (
                Random.Range(_boundary.xMin, _boundary.xMax), 
                _spawnEnemy.position.y,
                _spawnEnemy.position.z);
            
            enemy.transform.rotation = _spawnEnemy.transform.rotation;
            enemy.SetActive(true);
        }
    }

    internal static void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
