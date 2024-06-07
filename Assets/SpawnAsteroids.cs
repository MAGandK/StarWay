using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[System.Serializable]
public class BoundaryAsteroid
{
    public float xMin, xMax;
}
public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroids;
    [SerializeField] private Transform _spawnAsteroids;
    [SerializeField] private int _initialSize;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private BoundaryAsteroid _boundaryAsteroid;
    
    private List<GameObject> _asteroidsPrefabs;
    private float _timer;

    private void Start()
    {
        _asteroidsPrefabs = new List<GameObject>();

        for (int i = 0; i < _initialSize; i++)
        {
            GameObject newAsteroidPrefab = Instantiate(_asteroids[Random.Range(0,_asteroids.Length)]);
            newAsteroidPrefab.SetActive(false);
            _asteroidsPrefabs.Add(newAsteroidPrefab);
        }
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            SpawnAsteroid();
        }
    }
    
    internal GameObject GetPoolAsteroid()
    {
        foreach (var asteroid in _asteroidsPrefabs)
        {
            if (!asteroid.activeInHierarchy)
            {
                return asteroid;
            }
        }
        GameObject newAsteroid  = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)]);
        newAsteroid .SetActive(false);
        _asteroidsPrefabs.Add(newAsteroid );
        return newAsteroid ;
    }
    private void SpawnAsteroid()
    {
        GameObject asteroid = GetPoolAsteroid();

        if (asteroid != null)
        {
            asteroid.transform.position = new Vector3(Random.Range(_boundaryAsteroid.xMin, _boundaryAsteroid.xMax), 
                _spawnAsteroids.position.y, _spawnAsteroids.position.z);
            
            asteroid.transform.rotation = _spawnAsteroids.transform.rotation;
            asteroid.SetActive(true);
        }
    }

    internal static void ReturnAsteroidToPool(GameObject asteroid)
    {
        asteroid.SetActive(false);
    }
}
