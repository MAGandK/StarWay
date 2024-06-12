using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMove : MonoBehaviour
{
   [SerializeField] private float _speedMix;
   [SerializeField] private float _speedMax;

   private int _speed;
   private Rigidbody _rbAsteroid;

   private void Start()
   {
      _rbAsteroid = GetComponent<Rigidbody>();
      
      _speed = (int)Random.Range(_speedMix, _speedMax);
      _rbAsteroid.velocity = transform.forward * -_speed;
   }
}
