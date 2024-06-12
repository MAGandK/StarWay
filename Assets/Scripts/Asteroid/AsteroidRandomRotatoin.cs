using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidRandomRotatoin : MonoBehaviour
{
    [SerializeField] private float _tumbleMin;
    [SerializeField] private float _tumbleMax;
    
    private int _tumble;
    private Rigidbody _rbAsteroid;

    private void Start()
    {
        _rbAsteroid = GetComponent<Rigidbody>();
        
        _tumble = (int)Random.Range(_tumbleMin, _tumbleMax);
        _rbAsteroid.angularVelocity = Random.insideUnitSphere * _tumble;
    }
}
